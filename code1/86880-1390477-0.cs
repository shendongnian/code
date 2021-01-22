        public List<CategoryInfo> GetCategoryList()
        {
            List<CategoryInfo> categories = new List<CategoryInfo>();
            categories.Add(new CategoryInfo { Name = "Food<äü", Key = "VOC<420 g/l", ID = 2, Uid = new Guid("C0FD4706-4D06-4A0F-BC69-1FD0FA743B07") });
        }
        public ActionResult Category(ProductViewModel model )
        {
            IEnumerable<SelectListItem> categoryList  =
                                       from category in GetCategoryList()
                                       select new SelectListItem
                                       {
                                           Text = category.Name,
                                           Value = category.Key
                                       };
            model.CategoryList = categoryList;
          return View(model);
        }
