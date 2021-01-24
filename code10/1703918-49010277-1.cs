    foreach (var item in GetItemsQueryable<DeviceReading>()
        .Where(m => m.MetricType == "Temperature" && m.DeviceId == "XMS-0001")
        .OrderBy(m => m.MetricValue))
    {
        Console.WriteLine(item.MetricValue);
    }
