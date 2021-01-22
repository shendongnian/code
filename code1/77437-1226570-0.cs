    private Control GetVehicleControl(IVehicle vehicle)
    {
        Control result = (Control)Activator.CreateInstance(
            _vehicleToControlTypeMappings[(vehicle as object).GetType()]
            );
        // perform additional initialization of the control
        return result;
    }
