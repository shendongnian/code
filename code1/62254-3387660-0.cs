    public static TimeSpan GetUptime()
    {
        ManagementObject mo = new ManagementObject(@"\\.\root\cimv2:Win32_OperatingSystem=@");
        DateTime lastBootUp = ManagementDateTimeConverter.ToDateTime(mo["LastBootUpTime"].ToString());
        return DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime();
    }
