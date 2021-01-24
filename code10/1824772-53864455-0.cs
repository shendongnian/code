    public ActionResult Index()
    {
        //Populate your MenuItemsViewModel from database here
        MenuItemsViewModel menuItems = DB.GetMenuItems(); //Assuming GetMenuItems() is method which returns an object of type MenuItemsViewModel from database
        ViewBag.MenuItems = menuItems;
        return View();
    }
