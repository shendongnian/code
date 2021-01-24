            byte[] package= Encoding.ASCII.GetBytes(udpInfo[2].ToString());
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(udpInfo[0].ToString()), Convert.ToInt32(udpInfo[1]));
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    
            try
            {
                sock.SendTo(package, ep); //send packet to sw ip
                Console.WriteLine("package sent");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("package can't sent");
                return false;
            }
