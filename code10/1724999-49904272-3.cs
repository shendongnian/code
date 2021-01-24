     [HttpPost]
        public ActionResult EditTestCategory(Admin_TestCategory viewModel)
        {
            var testCatService = new TestCategoryService();
            Admin_TestCategory categoryToEdit = testCatService.GetById(viewModel.TestCategoryId);
            if(ModelState.IsValid)
            {
                categoryToEdit.TestCategoryName = viewModel.TestCategoryName;
                categoryToEdit.CreatedBy = viewModel.CreatedBy;
                //etc
                testCatService.UpdateTestCategory(categoryToEdit);
            }
            return RedirectToAction("TestCategory", "Admin");
        }
