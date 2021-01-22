            public List<CategoryInfo> GetCategoryList()
        {
            List<CategoryInfo> categories = new List<CategoryInfo>();
            categories.Add( new CategoryInfo{ Name="Beverages", Key="Beverages"});
            categories.Add( new CategoryInfo{ Name="Food", Key="Food"});
            categories.Add(new CategoryInfo { Name = "Food1", Key = "Food1" });
            categories.Add(new CategoryInfo { Name = "Food2", Key = "Food2" });
            return categories;
        }
	    public class ProductViewModel
	    {
	        public IEnumerable<SelectListItem> CategoryList { get; set; }
	        public IEnumerable<string> CategoriesSelected { get; set; }
	    }
        public ActionResult Category(ProductViewModel model )
        {
          IEnumerable<SelectListItem> categoryList =
                                    from category in GetCategoryList()
                                    select new SelectListItem
                                    {
                                        Text = category.Name,
                                        Value = category.Key,
                                        Selected = (category.Key.StartsWith("Food"))
                                    };
          model.CategoryList = categoryList;
          return View(model);
        }
