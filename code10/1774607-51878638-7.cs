    public ActionResult Index()
            {
                using (MenuMaster db = new MenuMaster())
                {
                    List<MenuMaster> list = db.MyMenus().ToList();
                    ViewBag.MenuList = list;
                }
                return View();
            }
