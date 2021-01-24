    public ActionResult Index()
    {
        using (MenuMaster db = new MenuMaster())
        {
            List<MenuMaster> list = db.MyMenus().ToList();
            Session["MenuList"] = list;
        }
        return View();
    }
