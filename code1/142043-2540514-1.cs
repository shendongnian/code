    ManagementClass objMC = new ManagementClass(
                            "Win32_NetworkAdapterConfiguration");
    ManagementObjectCollection objMOC = objMC.GetInstances();
    
    Console.WriteLine("Name\tIP Address\tMAC Address\tType");
    
    foreach (ManagementObject objMO in objMOC)
    {
      StringBuilder builder = new StringBuilder();
      builder.Append(objMO["Description"].ToString());
      builder.Append("\t");
      object o = objMO.GetPropertyValue("IPAddress");
      if (o != null)
          builder.Append(((string[])(objMO["IPAddress"]))[0].ToString());
      else
          builder.Append("NULL");
      builder.Append("\t");
      object m = objMO.GetPropertyValue("MACAddress");
      if (m != null)
          builder.Append(m.ToString());
      else
          builder.Append("NULL");
      
      builder.Append("\t");
      builder.Append(Convert.ToBoolean(objMO["DHCPEnabled"]) ? "DHCP" : "Static");
      Console.WriteLine(builder.ToString());
    }
