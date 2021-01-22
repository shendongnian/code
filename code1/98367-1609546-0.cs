    using System.Net.NetworkInformation;
     
    ...
    
    static void ViewNetworkInfo()
    {
        NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface nw in networks)
        {
            Console.WriteLine(nw.Name);
            Console.WriteLine(nw.GetPhysicalAddress().ToString());
                
            IPInterfaceProperties ipProps = nw.GetIPProperties();
            foreach (UnicastIPAddressInformation ucip in ipProps.UnicastAddresses)
            {  
                Console.WriteLine(ucip.Address.ToString());
            } 
            Console.WriteLine();
         }
         Console.ReadKey();
    }
