            string printerName = "Ricoh-L4-1";
            string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject printer in coll)
            {
                foreach (PropertyData property in printer.Properties)
                {
                    listBox1.Items.Add(string.Format("{0}: {1}", property.Name, property.Value));
                }
            } 
        }
