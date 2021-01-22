    using System.Management;
 
    ObjectQuery query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration"); 
    ManagementObjectCollection queryCollection = query.Get();
    foreach( ManagementObject mo in queryCollection )
    {
         foreach(string s in addresses)
         { 
                Console.WriteLine( "IP Address ‘{0}’", s); 
         }
         foreach(string s in subnets)
         { 
                Console.WriteLine( "IP Subnet ‘{0}’", s); 
         }
    }
