    [HttpGet]
    public PartialViewResult IndexGrid(String search)
    {
        if (String.IsNullOrEmpty(search))
            return PartialView("_IndexGrid", db.MasterCustomers.ToList());
        else
            return PartialView("_IndexGrid", db.MasterCustomers.Where(x => x.Code.Contains(search) || x.Name.Contains(search)).ToList());
    }
