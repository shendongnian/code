        [WebMethod]
        public static string GetUserType()
        {
            try
            {
                registerEntities1 db = new registerEntities1();
                var usertype = db.user_type_table.Select(x => new { x.user_id, x.user_name }).ToList();
                List<details> obj = new List<details>();
                foreach (var append in usertype)
                {
                    details objd = new details();
                    objd.pagename = append.user_name;
                    objd.Sno = append.user_id.ToString();
                    obj.Add(objd);
                }
                JavaScriptSerializer objsr = new JavaScriptSerializer();
                return objsr.Serialize(obj);
                //return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion
        #region display all page name in page load
        [WebMethod]
        public static string getDisplayALLPageName()
        {
            registerEntities1 db = new registerEntities1();
            var main_menu_list = db.page_name_table.Select(x => new { x.page_id, x.page_name }).ToList();
            var sub_menu_list = db.page_name_submenu.Select(x => new { x.page_id, x.page_name, x.main_menu_id }).ToList();
            List<mainMenu> MainMenuList = new List<mainMenu>();
            
            foreach (var main_menu in main_menu_list)
            {
                List<subMenu> SubMenuList = new List<subMenu>();
                mainMenu mainMenuDetails = new mainMenu();
                foreach (var sub_menu in sub_menu_list)
                {
                    subMenu sunMenuDetails = new subMenu();
                    if (main_menu.page_id == sub_menu.main_menu_id)
                    {
                        sunMenuDetails.id = sub_menu.page_id.ToString();
                        sunMenuDetails.pagename = sub_menu.page_name;
                        sunMenuDetails.menutype = "Sub menu";
                        //sunMenuDetails.submenulist = sub_menu_list.Count.ToString();
                        SubMenuList.Add(sunMenuDetails);
                    }
                }
                mainMenuDetails.id = main_menu.page_id.ToString();
                mainMenuDetails.pagename = main_menu.page_name;
                mainMenuDetails.menutype = "main Menu";
                mainMenuDetails.SubMenuList = SubMenuList;
                mainMenuDetails.mainmenulist = main_menu_list.Count.ToString();
                MainMenuList.Add(mainMenuDetails);
            }
            JavaScriptSerializer objsr = new JavaScriptSerializer();
            return objsr.Serialize(MainMenuList);
        }
