    private void packetCapturingThreadMethod()
    {
    
       Packet packet = null;
    
       while ((packet = device.GetNextPacket()) != null)
       {
            if (packet is UDPPacket)
            {
                UDPPacket udp = (UDPPacket)packet;
    
                MessageBox.Show(udp.ipv6.TrafficClass.ToString());
            }
       }
    }
