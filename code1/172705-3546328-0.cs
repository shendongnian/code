    // loop through the axes of an acquired device:
    foreach (DeviceObjectInstance doi in 
        _currentDevice.GetObjects(DeviceObjectTypeFlags.Axis))
    {
        doi.Name; // the name of the axis, e.g. 'X-Achse' (that's a german device...)
        doi.Offset / 4; // the enumeration 'index' of the axis
        doi.UsagePage; // the UsagePage determines the context of the axis value
        // vvvv
        doi.Usage; // the Usage tells you which JoystickState field to map to.
        // ^^^^
    }
