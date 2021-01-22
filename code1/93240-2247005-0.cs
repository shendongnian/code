	using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
	{
	    var endPoint = new IPEndPoint(ip, port);
	    socket.Bind(endPoint);
	    using (var client = new UdpClient() {Client = socket})
	    {
	        var destinationIP = IPAddress.Broadcast;
	        client.Connect(destinationIP, port);
	        client.Send(bytes, bytes.Length);
	    }
	}
