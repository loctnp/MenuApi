using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MenuApi.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class MenuController : ApiController
    {
        // [GET] api/menus
        [HttpGet]
        public List<Menu> getAllMenus()
        {
            MenusDataContext context = new MenusDataContext();
            List<Menu> menus = context.Menus.ToList();
            return menus;
        }

        // [GET] api/menus?parentid=...
        [HttpGet]
        public List<Menu> getAllChildMenus(int parentid)
        {
            MenusDataContext context = new MenusDataContext();
            List<Menu> menus = context.Menus.Where(x => x.parentid == parentid).ToList();
            return menus;
        }

        // [POST] api/menus
        [HttpPost]
        public bool addMenu(string name, int parentid)
        {
            try
            {
                MenusDataContext context = new MenusDataContext();
                Menu menu = new Menu();
                menu.name = name;
                menu.parentid = parentid;

                context.Menus.InsertOnSubmit(menu);
                context.SubmitChanges();
                return true;
            }
            catch { }
            return false;
        }

        // [POST] api/menus
        [HttpPost]
        public bool addMenu(string name)
        {
            try
            {
                MenusDataContext context = new MenusDataContext();
                Menu menu = new Menu();
                menu.name = name;

                context.Menus.InsertOnSubmit(menu);
                context.SubmitChanges();
                return true;
            }
            catch { }
            return false;
        }

        // [PUT] api/menus/id
        [HttpPut]
        public bool editMenu(int id, string name, int parentid)
        {
            try
            {
                MenusDataContext context = new MenusDataContext();
                Menu menu = context.Menus.FirstOrDefault(x => x.id == id);
                if (menu != null)
                {
                    menu.name = name;
                    menu.parentid = parentid;
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }

        // [PUT] api/menus/id
        [HttpPut]
        public bool editMenu(int id, string name)
        {
            try
            {
                MenusDataContext context = new MenusDataContext();
                Menu menu = context.Menus.FirstOrDefault(x => x.id == id);
                if (menu != null)
                {
                    menu.name = name;
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }

        // [Delete] api/menus/id
        [HttpDelete]
        public bool deleteMenu(int id)
        {
            try
            {
                MenusDataContext context = new MenusDataContext();
                Menu menu = context.Menus.FirstOrDefault(x => x.id == id);
                if (menu != null)
                {
                    context.Menus.DeleteOnSubmit(menu);
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }

    }
}
