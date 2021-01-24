    using ( var ctx = new MyEntities() )
    {
        ctx.Configuration.LazyLoadingEnabled = true;
        ctx.Configuration.AutoDetectChangesEnabled = false;
        ctx.Configuration.ValidateOnSaveEnabled = false;
        ctx.Configuration.ProxyCreationEnabled = false;
    
        var idList = ctx.Items.AsNoTracking().Where( y => y.StoreID == 223250 ).Select( y => y.Id ).AsQueryable();
    
        var storeTransactions = ctx.ItemTransactions.AsNoTracking().Where( r => idList.Contains( r.Id.Value ) ).ToList();
    
        return Json( "Ok" );
    }
