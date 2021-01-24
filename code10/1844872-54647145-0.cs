    public IList<Vehicle> GetAllByCat(int compId, short catId)
    {
        var _vehicles = Context.Vehicle
            .Include(x => x.VehicleCategories)
            .Where(i => 
                i.CompanyId == compId && 
                i.VehicleCategories.Any(o => o.VehicleCategoryId == catId))
            .ToList();
    
        return _vehicles;
    }
