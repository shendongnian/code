    //You need SharpPcap for this to work
    
    private void WakeFunction(string MAC_ADDRESS)
    {
        /* Retrieve the device list */
        Tamir.IPLib.PcapDeviceList devices = Tamir.IPLib.SharpPcap.GetAllDevices();
    
        /*If no device exists, print error */
        if (devices.Count < 1)
        {
            Console.WriteLine("No device found on this machine");
            return;
        }
    
        foreach (NetworkDevice device in devices)
        {
            //Open the device
            device.PcapOpen();
    
            //A magic packet is a broadcast frame containing anywhere within its payload: 6 bytes of ones
            //(resulting in hexadecimal FF FF FF FF FF FF), followed by sixteen repetitions 
    
            byte[] bytes = new byte[120];
            int counter = 0;
            for (int y = 0; y < 6; y++)
                bytes[counter++] = 0xFF;
            //now repeat MAC 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    bytes[counter++] =
                        byte.Parse(MAC_ADDRESS.Substring(i, 2),
                        NumberStyles.HexNumber);
                    i += 2;
                }
            }
    
            byte[] etherheader = new byte[54];//If you say so...
            var myPacket = new Tamir.IPLib.Packets.UDPPacket(EthernetFields_Fields.ETH_HEADER_LEN, etherheader);
    
            //Ethernet
            myPacket.DestinationHwAddress = "FFFFFFFFFFFFF";//it's buggy if you don't have lots of "F"s... (I don't really understand it...)
            try { myPacket.SourceHwAddress = device.MacAddress; }
            catch { myPacket.SourceHwAddress = "0ABCDEF"; }//whatever
            myPacket.EthernetProtocol = EthernetProtocols_Fields.IP;
    
            //IP
            myPacket.DestinationAddress = "255.255.255.255";
            try { myPacket.SourceAddress = device.IpAddress; }
            catch { myPacket.SourceAddress = "0.0.0.0"; }
            myPacket.IPProtocol = IPProtocols_Fields.UDP;
            myPacket.TimeToLive = 50;
            myPacket.Id = 100;
            myPacket.Version = 4;
            myPacket.IPTotalLength = bytes.Length - EthernetFields_Fields.ETH_HEADER_LEN;			//Set the correct IP length
            myPacket.IPHeaderLength = IPFields_Fields.IP_HEADER_LEN;
    
            //UDP
            myPacket.SourcePort = 9;				
            myPacket.DestinationPort = 9;			
            myPacket.UDPLength = UDPFields_Fields.UDP_HEADER_LEN;
    
    
            myPacket.UDPData = bytes;
            myPacket.ComputeIPChecksum();
            myPacket.ComputeUDPChecksum();
    
            try
            {
                //Send the packet out the network device
                device.PcapSendPacket(myPacket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
    
            device.PcapClose();
        }
    }
