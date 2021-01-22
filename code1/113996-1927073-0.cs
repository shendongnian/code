    public ViewResult NewBusiness(Business business)
    {
        _db.Create<Business>(business);
        return View();
    }
