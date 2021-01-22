    using System.Management;
    
    class Printer
        {
            public string Name { get; set; }
            public string Status { get; set; }
            public bool Default { get; set; }
            public bool Local { get; set; }  
            public bool Network { get; set; }        
            public string PrintProcessor { get; set; }
            public string PortName { get; set; }
        }
        
    
    
            private void btnGetPrinters_Click(object sender, EventArgs e)
            {          
               List<Printer> printers = new List<Models.Printer>();
                var query = new ManagementObjectSearcher("SELECT * from Win32_Printer");
                foreach (var item in query.Get())
                {
                    string portName = item["PortName"].ToString().ToUpper();
                    if (((bool)item["Local"]==true || (bool)item["Network"]==true) &&  (portName.StartsWith("USB") || portName.StartsWith("LPT")))
                    {
                        Printer p = new Models.Printer();
                        p.Name = (string)item.GetPropertyValue("Name");
                        p.Status = (string)item.GetPropertyValue("Status");
                        p.Default = (bool)item.GetPropertyValue("Default");
                        p.Local = (bool)item.GetPropertyValue("Local");
                        p.Network = (bool)item.GetPropertyValue("Network");                    
                        p.PrintProcessor = (string)item.GetPropertyValue("PrintProcessor");
                        p.PortName = (string)item.GetPropertyValue("PortName");
                        printers.Add(p);
                    }
                }
    
                //Show on GridView 
                gv.DataSource = printers;
            }
