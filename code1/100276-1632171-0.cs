        public static DateTime GetLastSystemShutdown()
        {
            string sKey = @"System\CurrentControlSet\Control\Windows";
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey);
            string sValueName = "ShutdownTime";
            object val = key.GetValue(sValueName);
            DateTime output = DateTime.MinValue;
            if (val is byte[] && ((byte[])val).Length == 8)
            {
                byte[] bytes = (byte[])val;
                System.Runtime.InteropServices.ComTypes.FILETIME ft = new System.Runtime.InteropServices.ComTypes.FILETIME();
                int valLow = bytes[0] + 256 * (bytes[1] + 256 * (bytes[2] + 256 * bytes[3]));
                int valTwo = bytes[4] + 256 * (bytes[5] + 256 * (bytes[6] + 256 * bytes[7]));
                ft.dwLowDateTime = valLow;
                ft.dwHighDateTime = valTwo;
                DateTime UTC = DateTime.FromFileTimeUtc((((long) ft.dwHighDateTime) << 32) + ft.dwLowDateTime);
                TimeZoneInfo lcl = TimeZoneInfo.Local;
                TimeZoneInfo utc = TimeZoneInfo.Utc;
                output = TimeZoneInfo.ConvertTime(UTC, utc, lcl);
            }
            return output;
        }
