    var results = await (
        from v in _context.Vehicles
        join r in _context.UnitRepairStatus() on v.VehicleNumber equals r.UnitNumber // <---
        orderby v.VehicleNumber
        select new FooViewModel { 
            ID = v.ID, 
            VehicleNumber = v.VehicleNumber,
            InRepair = Convert.ToBoolean(r.InRepair)
        }
    ).ToListAsync();
