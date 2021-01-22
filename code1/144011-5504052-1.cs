	using (var mem = new MemoryStream())
	{
	    using (var tcp = new TcpClient())
	    {
	        tcp.Connect(new IPEndPoint(IPAddress.Parse("192.0.0.192"), 8880));
	        tcp.GetStream().CopyTo(mem);
	    }
	    var bytes = mem.ToArray();
	}
