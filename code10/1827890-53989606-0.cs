    var categories = dataFromDb.AsEnumerable()
        .GroupBy(_ => _.Field<string>("CategoryName"))
        .Select(g => new {
            CategoryName = g.Key,
            SubCategories = g.Select(_ => _.Field<string>("SubcategoryName"))
        });
    foreach (var category in categories) {
        var name = category.CategoryName;
        //...Create GroupBox
        foreach (var subcategoryName in category.SubCategories) {
            //...Create CheckBbox with subcategoryName and add to groupbox
                    
        }
    }
