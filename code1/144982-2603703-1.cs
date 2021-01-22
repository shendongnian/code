    using (var ctx = new NorthwindDataContext()) {
        var categories = ctx.Categories;
        
        var catcopy = categories.Select(x => new CategoriesBackup() {
        	CategoryID = x.CategoryID,
        	CategoryName = x.CategoryName,
        	Description = x.Description,
        	Picture = x.Picture
        });
        //ctx.CategoriesBackups.InsertAllOnSubmit(catcopy);  // THIS DOES NOT WORK
        
        var catcopy2 = categories.AsEnumerable().Select(x => new CategoriesBackup() {
        	CategoryID = x.CategoryID,
        	CategoryName = x.CategoryName,
        	Description = x.Description,
        	Picture = x.Picture
        });
        ctx.CategoriesBackups.InsertAllOnSubmit(catcopy2);  // THIS WORKS
    }
