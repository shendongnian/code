     public ActionResult EditTestCategory(short id)
        {
            var testCatService = new TestCategoryService();
            var categoryToEdit = testCatService.GetById(id);
            //check if that category exists or not
            //category does not exist
            if (categoryToEdit == null)
                return HttpNotFound("Can not find the ID of the given Test Category");
            return View(categoryToEdit);
        }
