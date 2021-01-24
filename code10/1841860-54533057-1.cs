    using (var ctx = new MyEntities())
    {
        ctx.Configuration.LazyLoadingEnabled = false;
        ctx.Configuration.AutoDetectChangesEnabled = false;
        ctx.Configuration.ValidateOnSaveEnabled = false;
        ctx.Configuration.ProxyCreationEnabled = false;
        var storeItems = ctx.Items.AsNoTracking().Where(y => y.StoreID == 223250);
        var idList = storeItems.Select(y => y.Id); //removed ToList on this and previous line
        var storeTransactions = ctx.ItemTransactions.AsNoTracking()
                                   .Where(r => idList.Contains(r.Id.Value)).ToList();
        return Json("Ok");
    }
