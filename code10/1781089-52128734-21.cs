    public PartialViewResult GetFilteredData(int? id, string title)
    {
        var query = db.ProjectCategories.ToList();
    
        if (id != null)
            query = query.Where(x => x.id == id).ToList();
    
        if (!string.IsNullOrEmpty(title))
            query = query.Where(x => x.title == title).ToList();
    
        return PartialView("GetFilteredData", query);
    }
