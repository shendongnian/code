    string SimpleOSName()
    {
        var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                    select x.GetPropertyValue("Caption").ToString()).First();
        var parts = name.Split(" ").ToArray();
        return String.Join(" ", parts.Skip(parts.IndexOf("Windows")).Take(2));
    }
