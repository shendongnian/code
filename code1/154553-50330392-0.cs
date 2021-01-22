        public static string OS_Name()
        {
            return (string)(from x in new ManagementObjectSearcher(
                "SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>() 
                select x.GetPropertyValue("Caption")).FirstOrDefault();
        }
