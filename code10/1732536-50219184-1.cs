    var data =
        (from device in context.Devices
         select new DeviceData
         {
             DeviceName = device.Name,
             DeviceType = device.Type.ShortName,
             Monitors = 
                 (from monitor in device.Monitors
                  let sample = (from s in monitor.Samples
                                orderby s.Time descending
                                select s).FirstOrDefault()
                  select new MonitorSampleData
                  {
                      Name = monitor.Name,
                      Time = sample.Time,
                      Sequence = monitor.Sequence,
                      Type = monitor.DataType.Name,
                      Unit = monitor.UnitType.Name,
                      Value = sample.Value
                  }).ToList()
         }).ToList();
