            using System.Management;
            ManagementObjectSearcher query = new
                ManagementObjectSearcher("SELECT * FROM Win32_WMISetting") ;
            ManagementObjectCollection items = query.Get();
            foreach (ManagementObject mo in items)
            {
                System.Console.WriteLine(mo["BuildVersion"]);
            }
