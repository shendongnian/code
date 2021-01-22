    public string SimpleOSName()
    {
        var name = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem")
            .Get().Cast<ManagementObject>()
            .Select(x => x.GetPropertyValue("Caption").ToString())
            .First();
        var parts = name.Split(' ').ToArray();
        return string.Join(" ", parts.Skip(parts.IndexOf("Windows")).Take(2));
    }
