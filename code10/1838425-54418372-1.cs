    public void GetCategories(int level) {
       var categories = db.Categories.Where(c => c.ParentCategoryId == 0).ToList();
       var parents = categories.Select(c => c.Id);
       for (var ii = 0; ii < level; ii++) {
          var newCategories = db.Categories.Where(c => parents.Contains(c.ParentCategoryId).ToList();  
          parents = newCategories.Select(c => c.Id);
          categories = categories.Concat(newCategories);
    }
    
       var result = categories;
    }
