            WMIHelper helper = new WMIHelper("root\\CimV2");
            string pid = "-";
            string name = "-";
            string path = "-";
            string priort = "-";
            string user = "-";
            var processes = helper.Query("Select * From Win32_Process").ToList();
            foreach (var p in processes)
            {
                pid = p.ProcessID;
                name = p.Name;
                path = p.ExecutablePath ?? String.Empty;
                priort = p.Priority ?? String.Empty;
            }
