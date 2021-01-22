    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
    s.Bind(new IPEndPoint(IPAddress.Parse("<IP Address Here of NIC to sniff>"), 0));
    s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, 1);
    byte[] inBytes = new byte[] { 1, 0, 0, 0 };
    byte[] outBytes = new byte[] { 0, 0, 0, 0 };
    s.IOControl(IOControlCode.ReceiveAll, inBytes, outBytes);
