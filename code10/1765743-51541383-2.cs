    var shipment = _myDbContext.Shipments
                    .Include(s => s.WarehouseAllocations)
                    .ThenInclude(s => s.Dispatches)
                    .ThenInclude(s => s.DispatchDetails)
                    .Include(s => s.WarehouseAllocations)
                    .SingleOrDefault(s => s.WarehouseAllocations.Select(w => w.Id).Contains(warheouseAllocationId));
