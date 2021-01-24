    [HttpGet]
    public IEnumerable<VehicleDto> GetVehicles()
    {
        return Mapper.Map<IList<Vehicle>, List<VehicleDto>>(_context.Vehicles.ToList());
    }
