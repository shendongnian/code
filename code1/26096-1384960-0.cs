    foreach( ManagementObject volume in 
                 new ManagementObjectSearcher("Select * from Win32_Volume" ).Get())
    {
      if( volume["FreeSpace"] != null )
      {
        Console.WriteLine("{0} = {1} out of {2}",
                      volume["Name"],
                      ulong.Parse(volume["FreeSpace"].ToString()).ToString("#,##0"),
                      ulong.Parse(volume["Capacity"].ToString()).ToString("#,##0"));
      }
    }
