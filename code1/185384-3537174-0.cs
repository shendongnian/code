    foreach(TimeZoneInfo info in TimeZoneInfo.GetSystemTimeZones())
    {
        Console.WriteLine("Id: {0}", info.Id);
        Console.WriteLine("   DisplayName: {0}", info.DisplayName);
    }
