    using System.Management;
     ManagementObjectSearcher search =
                 new ManagementObjectSearcher("root\\CIMV2","SELECT * FROM Win32_ConnectionShare"); 
            foreach (ManagementObject MO in search.Get())
            {
                string antecedent = MO["antecedent"].ToString();
                ManagementObject share = new ManagementObject(antecedent);
    
                string dependent = MO["dependent"].ToString();
                ManagementObject server = new ManagementObject(dependent);
    
                string userName = server["UserName"].ToString();
                string compname = server["ComputerName"].ToString();
                string sharename = server["ShareName"].ToString();
            }
