    public void GetCategories(int level) {
       var categories = db.Categories.Where(c => c.ParentCategoryId == 0).ToList();
       for (var ii = 0; ii < level; ii++) {
          var parents = categories.Select(c => c.Id);
          var newCategories = db.Categories.Where(c => parents.Contains(c.ParentCategoryId).ToList();  
          categories = categories.Concat(newCategories);
    }
    
       var result = categories;
    }
