    {
        List<Vehicle> vehicles;
        // Using a lambda
        vehicles.RemoveAll(vehicle => vehicle.EnquiryID == 123);
        // Using an equivalent anonymous method
        vehicles.RemoveAll(delegate(Vehicle vehicle)
        {
            return vehicle.EnquiryID == 123;
        });
        // Using an equivalent actual method
        vehicles.RemoveAll(VehiclePredicate);
    }
    private static bool VehiclePredicate(Vehicle vehicle)
    {
        return vehicle.EnquiryID == 123;
    }
