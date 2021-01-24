    [HttpGet]
    public IEnumerable<VehicleDto> GetVehicles()
    {
        return _context.Vehicles.Select(v => Mapper.Map<Vehicle, VehicleDto>(v)).ToList();
    }
