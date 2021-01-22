    ManagementClass objMC = new ManagementClass(
                            "Win32_NetworkAdapterConfiguration");
    ManagementObjectCollection objMOC = objMC.GetInstances();
    
    Console.WriteLine("Name\tIP Address\tMAC Address\tType");
    
    foreach(ManagementObject objMO in objMOC)
    {
    
       StringBuilder builder = new StringBuilder();
    
       builder.Append(objMO["Description"].ToString());
       builder.Append("\t");
       builder.Append((objMO["IPAddress"][0]).ToString());
       builder.Append("\t");
       builder.Append(objMO["MACAddress"].ToString());
       builder.Append("\t");
       builder.Append(Convert.ToBoolean(objMO["DHCPEnabled"]) ? "DHCP" : "Static");  
       Console.WriteLine(builder.ToString());
    }
