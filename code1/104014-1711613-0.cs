    output = DateTime.TryParse(userDate, out date);
    if (!output)
    {
        // Throw an error
        return -3;  // ***** Changed this line
    }
    int Device;
    output = int.TryParse(DeviceID, out Device);
    if (!output)
    {
        // Throw an Error
        return -2;  // ***** Changed this line
    }
