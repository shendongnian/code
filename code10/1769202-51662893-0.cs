    var query = context.StorageAreaRacks
        .Where(sar => !sar.StorageArea.StorageAreaType.IsManual
            && sar.Rack.IsEnabled && !sar.Rack.IsVirtual)
        .Select(sar => new
        {
            sar.StorageArea.StorageAreaType.Id,
            sar.StorageArea.StorageAreaType.Name,
        })
        .Distinct();
  
