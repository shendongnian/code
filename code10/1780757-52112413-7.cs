    public PartialViewResult GetItem(int id)
    {
        var charts = db.ProjectCategories.ToList();
        var model = charts.Where(x => x.id == id).ToList();
        return PartialView("_GetItem", model);
    }
