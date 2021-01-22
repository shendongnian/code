    // Get adapter hardware address and IP address
      Adapter oAdapter = (Adapter)oPktX.Adapter;
      string sHWAddr = oAdapter.HWAddress;
      string sIPAddr = oAdapter.NetIP;
      string sIPMask = oAdapter.NetMask;
      Console.WriteLine("MAC Addr = " + sHWAddr);
      Console.WriteLine("IP  Addr = " + sIPAddr);
      // Send ARP request for this IP address
      string sIPReso = "11.12.13.14";
      char [] aDelimiter = {'.'};
      string[] aIPReso = sIPReso.Split(aDelimiter, 4);
      string[] aIPAddr = sIPAddr.Split(aDelimiter, 4);
      // Build ARP packet
      Object[] oPacket = new Object[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
        Convert.ToByte("0x" + sHWAddr.Substring(0,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(2,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(4,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(6,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(8,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(10,2), 16),
        0x08, 0x06, 0x00, 0x01,
        0x08, 0x00, 0x06, 0x04, 0x00, 0x01,
        Convert.ToByte("0x" + sHWAddr.Substring(0,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(2,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(4,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(6,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(8,2), 16),
        Convert.ToByte("0x" + sHWAddr.Substring(10,2), 16),
        Convert.ToByte(aIPAddr[0], 10),
        Convert.ToByte(aIPAddr[1], 10),
        Convert.ToByte(aIPAddr[2], 10),
        Convert.ToByte(aIPAddr[3], 10),
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        Convert.ToByte(aIPReso[0], 10),
        Convert.ToByte(aIPReso[1], 10),
        Convert.ToByte(aIPReso[2], 10),
        Convert.ToByte(aIPReso[3], 10),
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
      // Send 100 ARP requests      
      oAdapter.SendPacket(oPacket, 100);
