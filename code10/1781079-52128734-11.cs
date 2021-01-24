    public PartialViewResult GetProjectCategory(int id)
    {
        var projects = db.ProjectCategories.ToList();
        var model = projects.Where(x => x.id == id).ToList();
        return PartialView("_GetProjectCategory", model);
    }
    
    public PartialViewResult GetFundCategory(int id)
    {
        var funds = db.FundCategories.ToList();
        var model = funds.Where(x => x.id == id).ToList();
        return PartialView("_GetFundCategory", model);
    }
