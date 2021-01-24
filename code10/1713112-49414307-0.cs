        public ActionResult Create()
    {
        ItemViewModel ivm = new ItemViewModel();
        // not sure what you are doing with this var categoryBusiness = new CategoryBusiness();
        ivm.CategoriesSelectionListItem = new SelectList(categoryBusiness.GetAllCategories(), "CategoryId", "Name");
        return View(ivm);
    }
