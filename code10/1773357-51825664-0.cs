    public bool Print(string printerName, string printerTray = null, int? copies = 1) 
    {
        if(copies == null || copies < 1)
        {
            return false;        
        }
    
        if (printerName.IsDefined() && printerTray.IsDefined()) 
        {
            project.Regions[0].Device.Name = "\" "
                                           + "".Combine(printerName, printerTray)  
                                           + "\" ";
        }
    }
