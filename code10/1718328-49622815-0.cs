    while (rd.Read())
    {
        var device = new DeviceModlInfo
        {
            ID = rd.GetGuid("ID"),
            Manufacturer = new Manufacturer()
            {
               ID = rd.GetGuid("ManufacturerID"),
               Name = rd.GetString("ManufacturerName"),
               ManufacturerType (ManufacturerEnum)rd.GetInt32("ManufecturerType")
            },
            Model = rd.GetString("Model");
        };
        if (rd.GetName(i).Equals("IMEI", StringComparison.InvariantCultureIgnoreCase))
        {
            device.IMEI = rd.GetString("IMEI");
        }
        list.Add(device);
     }
