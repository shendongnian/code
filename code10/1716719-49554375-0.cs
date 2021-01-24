    [Authorize] //make sure they're logged in
    public ActionResult Index()
    {
        string _viewSuffix = "";
        //this bit would have to be hierarchical - high to low - so you have a degradation of what the view offers...
        if (User.IsInRole("Admin")) 
        {
            _viewSuffix = "Admin";
        }
        else if(User.IsInRole("Test"))
        {
            _viewSuffix = "Test";
        }
        //...and so on
        return View("Index" + _viewSuffix);
    } 
