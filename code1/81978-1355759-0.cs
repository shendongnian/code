    var qryCategories = from q in ctx.Categories
                        where q.Status == "Open"
                        select q;
    foreach (Category cat in qryCategories) {
        if (!cat.Items.IsLoaded)
            cat.Items.Load();
        // This will only load product groups "once" if need be.
        if (!cat.ProductGroupReference.IsLoaded)
            cat.ProductGroupReference.Load();
        foreach (Item item in cat.Items) {
            // product group and items are guaranteed
            // to be loaded if you use them here.
        }
    }
