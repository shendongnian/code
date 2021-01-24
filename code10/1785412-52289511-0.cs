    var vehicle = odata.SingleOrDefault(x => x.VehicleNo.Equals(ddVehicleNo.SelectedValue));
    if (vehicle != null)
    {
        var vehicleType = vehicle.VehicleType;
    }
    else
    {
        // set combobox's SelectedIndex to -1
    }
