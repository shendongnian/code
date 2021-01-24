    var deviceHierarchyDataItems = devices
        .SelectMany(device => device.Meters.Select(meter => new DeviceHierarchyDataItem
        {
            Id = meter.Id,
            ChildOf = device.Id,
            CircuitConnectId = 0, // don't know what you need here
            DisplayName = meter.MeterName
        }).Concat(new List<DeviceHierarchyDataItem>()
        {
            new DeviceHierarchyDataItem
            {
                Id = device.Id,
                ChildOf = null,
                CircuitConnectId = 0, // don't know what you need here
                DisplayName = device.DeviceName
            }
        }));
