    [HttpGet]
    public IEnumerable<Vehicle> GetVehicles()
    {
        return Mapper.Map<IList<VehicleDto>, List<Vehicle>>(_context.Vehicles.ToList());
    }
