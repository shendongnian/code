        static DateTime getLastBootTime(ManagementObject mObject)
        {
            PropertyData pd = mObject.Properties["LastBootUpTime"];
            string name = pd.Name.ToString();
            DateTime lastBoot = parseCmiDateTime(pd.Value.ToString());
            return lastBoot;
        }
        
        static ManagementObject getServerOSObject(string serverName)
        {
            ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");
            mSearcher.Scope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", serverName));
            ManagementObjectCollection mObjects = mSearcher.Get();
            if (mObjects.Count != 1) throw new Exception(String.Format("Expected 1 object, returned {0}.", mObjects.Count));
            foreach (ManagementObject m in mObjects)
            {
                //No indexing on collection
                return m;
            }
            throw new Exception("Something went wrong!");
        }
