    var vehicleProperties = typeof(Program).GetProperties()
        .Where(p =>
            p.PropertyType.IsGenericType &&
            p.PropertyType.GetGenericTypeDefinition() == typeof(VehicleCollection<>))
        .ToList();
