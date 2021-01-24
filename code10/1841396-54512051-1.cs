    [HttpPost]
    public ActionResult createSubCategory(int? id, SubCategoryVM model)
    {
        SubCategory sc = new SubCategory();
        if (ModelState.IsValid)
        {
            sc.ParentName = model.ParentName;
            sc.Name = model.Name;
        }
        var cNames = db.Categories.ToList();
        model.categoryNames = cNames.Select(x
            => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });
    
        return View(model);
    }
