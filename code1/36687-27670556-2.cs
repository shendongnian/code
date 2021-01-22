            using System;
            using System.Management;
            ManagementClass osClass = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject queryObj in osClass.GetInstances())
            {
                foreach (PropertyData prop in queryObj.Properties)
                {
                    if (prop.Name == "ProductType")
                    {
                        ProdType = int.Parse(prop.Value.ToString());
                    }
                }
            }
        
