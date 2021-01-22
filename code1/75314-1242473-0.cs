        var query =
        from g in cdc.Global
        where g.active == true && g.globalId == 41
        select g;
        var globalList = query.ToList();
        List<Category> categoryList = g.category.ToList<Category>();
        var categoryIds = from c in cdc.Category
                    where c.globalId == g.globalId
                    select c.categoryId;
        var types = from t in cdc.ItemTypes
                    where categoryIds.Any(i => i == t.categoryId)
                    select t;
        List<ItemType> TypeList = types.ToList<ItemType>();
        
        var items = from i in cdc.Items
                    from d in cdc.ItemData
                    where i.ItemId == d.ItemId && d.labelId == 1
                    where types.Any(i => i == r.ItemTypes)
                    select new 
                        {
                            i.Id, 
                            // A Bunch of more fields shortened for berevity
                            d.Data    
                        };
        var ItemList = items.ToList();
        
        // Keep on going down the hierarchy if you need more child results
        // Do your processing psuedocode
        for each item in list
            filter child list
            for each item in child list
                .....
        // 
