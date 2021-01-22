       public static string GetMacAndDescription()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
            string mac = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();
            string description = (from o in objects orderby o["IPConnectionMetric"] select o["Description"].ToString()).FirstOrDefault();
            return mac + ";" + description;
        }
        public static string GetMacByDescription( string description)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
            string mac = (from o in objects where o["Description"].ToString() == description select o["MACAddress"].ToString()).FirstOrDefault();
            return mac;
        }
