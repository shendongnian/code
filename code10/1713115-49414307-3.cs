        public ActionResult Create()
    {
        ItemViewModel ivm = new ItemViewModel();
        var categoryBusiness = new CategoryBusiness();
        ivm.CategoriesSelectionListItem = new SelectList(categoryBusiness.GetAllCategories(), "CategoryId", "Name");
        return View(ivm);
    }
