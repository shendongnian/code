            string ret = "";
            string RemoteIP = "";
            int RemotePort = 0;
            SendCommand("PASV");
            int id =0;
            id = strMsg.LastIndexOf(')');
            if( id!=0) 
            {
                string tmp = strMsg.Substring(strMsg.LastIndexOf('(')+1, id-strMsg.LastIndexOf('(')-1);
                string[] bByte = tmp.Split(',');
                RemotePort = int.Parse(bByte[4]) * 256 + Byte.Parse(bByte[5]);
                RemoteIP = bByte[0]+"." + bByte[1] + "." + bByte[2] + "." + bByte[3];
            }
            Socket NewConn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint RemoteIPPort = new IPEndPoint(IPAddress.Parse(RemoteIP), RemotePort);
            try
            {
                NewConn.Connect(RemoteIPPort);
            }
            catch
            {
                throw new IOException("unable to Connect  !");
            }
            return NewConn;
        }
