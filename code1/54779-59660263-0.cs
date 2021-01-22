    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
    {
         if (nic.OperationalStatus == OperationalStatus.Up)
         {
                PhysicalAddress Mac = nic.GetPhysicalAddress();
         }
    }
