    foreach (dynamic obj in WMIQuery.GetAllObjects(Win32.PointingDevice))
    {
        Console.WriteLine(obj.Name);
        Console.WriteLine(obj.Manufacturer);
        Console.WriteLine(obj.DeviceID);
    }
