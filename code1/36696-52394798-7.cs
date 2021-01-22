    string SimpleOSName()
    {
        var name = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem")
            .Get().Cast<ManagementObject>()
            .Select(x => x.GetPropertyValue("Caption").ToString())
            .First();
        var parts = name.Split(' ').ToArray();
        var take = name.Contains("Server")?3:2;
        return string.Join(" ", parts.Skip(parts.IndexOf("Windows")).Take(take));
    }
