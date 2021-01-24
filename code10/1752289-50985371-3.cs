        string query = "select * from Win32_LogicalDiskToPartition";
        string antecedent = @"\\" + Environment.MachineName + "\\root\\cimv2:Win32_DiskPartition.DeviceID=\"" + deviceid + "\"";
            ManagementObjectSearcher moSearch = new ManagementObjectSearcher(query);
            ManagementObjectCollection moCollection = moSearch.Get();
    
            foreach (ManagementObject mo in moCollection)
            {
                if (string.Equals(mo["Antecedent"].ToString(), antecedent))
                    Console.WriteLine("Dependent: " + mo["Dependent"]);
            }
