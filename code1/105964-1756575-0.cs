    using System;
    using System.Collections.Generic;
    using System.Management;
    using ROOT.CIMV2.Win32;
    
    public class MyClass
    {
    	public static void Main()
    	{
    		
    		foreach (POTSModem modem in POTSModem.GetInstances()) {
    			Console.WriteLine(modem.Description);
    		}
    	}
   	
    }
    
    
