    var Duplicates = 
        items.GroupBy(store => store.StoreNumber)
             .Select(grp => grp.Where(store => store.IsResolved == false))
             .Where(stores => stores.Count() > 1 && stores.Select(w => w.WarehouseNumber).Distinct().Count() == 1)
             .SelectMany(stores => stores)
             .ToList();
    var Overlapping = 
        items.GroupBy(store => store.StoreNumber)
             .Select(grp => grp.Where(store => store.IsResolved == false))
             .Where(store => store.Count() > 1 && store.Select(w => w.WarehouseNumber).Distinct().Count() > 1)
             .SelectMany(stores => stores)
             .ToList();
    Overlapping.ForEach(ovr =>
        Console.WriteLine($"{ovr.StoreNumber} " +
                          $"{ovr.WarehouseNumber} " +
                          $"{ovr.IsResolved} " +
                          $"{ovr.StoreName} " +
                          $"{ovr.WarehouseName}"));
