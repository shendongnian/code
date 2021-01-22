    private void GetAllPrinterList()
            {
                ManagementScope objScope = new ManagementScope(ManagementPath.DefaultPath); //For the local Access
                objScope.Connect();
     
                SelectQuery selectQuery = new SelectQuery();
                selectQuery.QueryString = "Select * from win32_Printer";
                ManagementObjectSearcher MOS = new ManagementObjectSearcher(objScope, selectQuery);
                ManagementObjectCollection MOC = MOS.Get();
                foreach (ManagementObject mo in MOC)
                {
                    lstPrinterList.Items.Add(mo["Name"].ToString());
                }
            }
