        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            
                    foreach (ManagementObject printer in searcher.Get())
                    {
                        string printerName = printer["Name"].ToString().ToLower();
                        Console.WriteLine("Printer :" + printerName);
                        PrintProps(printer, "Status");
                        PrintProps(printer, "PrinterState");
                        PrintProps(printer, "PrinterStatus");
                        
            
                    }
    
    }
    
    static void PrintProps(ManagementObject o, string prop)     
    {         
    		try { Console.WriteLine(prop + "|" + o[prop]); 
    		}         
    		catch (Exception e) 
    		{ 
    			Console.Write(e.ToString()); 
    		}     
    }   
 
