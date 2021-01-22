       ManagementScope scope = new ManagementScope(@"\root\cimv2");
       scope.Connect();
    
       // Select Printers from WMI Object Collections
    
       ManagementObjectSearcher searcher = new 
        ManagementObjectSearcher("SELECT * FROM Win32_Printer");
    
       string printerName = "";
       foreach (ManagementObject printer in searcher.Get()) 
       {
        printerName = printer["Name"].ToString().ToLower();
        if (printerName.Equals(@"hp deskjet 930c"))
        {
         Console.WriteLine("Printer = " + printer["Name"]); 
         if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
         {
          // printer is offline by user
    
          Console.WriteLine("Your Plug-N-Play printer is not connected.");
         }
         else
         {
          // printer is not offline
    
           Console.WriteLine("Your Plug-N-Play printer is connected.");
         }
        }
       }
      }
