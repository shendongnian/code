    private void QueryServer(IPAddress IP, int Port)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes("\\100 * 1024\\");
            udpClient.Connect(IP, Port);
            udpClient.Client.EnableBroadcast = true;
            // Set DontFragment to true. We won't be sending packets larger than the maximum allowed, but it's the
            // peace of mind that counts. Read about DontFragment on the MSDN.
            udpClient.Client.DontFragment = true;
            // Create an IPEndPoint object to hold our target. We are sending to the Broadcast address which means
            // all machines on this network listening on the port specified by argument #2 will get a copy of
            // this packet.
            IPEndPoint target = new IPEndPoint(IP, Port);
            // We will be sending a single packet. This is highly inaccurate and I wouldn't be caught doing this in a
            // major application, but this is a basics tutorial.
            // Make a call to SendTo. This is a special kind of function as it requires no confirmation of the remote
            // host even being alive. You can use SendTo on an application that isn't listening, the packet will send
            // but you will not get a reply.
            udpClient.Client.SendTo(sendBytes, (EndPoint)target);
            byte[] reply = new byte[2000];
            // Create a new EndPoint to hold the network information of the sender.
            EndPoint remote = ((EndPoint)new IPEndPoint(IP, Port));
            int i = udpClient.Client.ReceiveFrom(reply, ref remote);
            ProcessPacket(reply, i, remote);
        }
