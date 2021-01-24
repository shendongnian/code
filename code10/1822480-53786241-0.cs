    public ActionResult Index()
    {
        var customers = _dbContext.Customers.Include(c => c.Type).ToList();
        if (User.IsInRole(userRole.IsAdministator))
        {
            return View("Admin_List_View", customers);
        } else
        {
            return View("Customer_ReadOnlyList_View" , customers);
        }
    }
