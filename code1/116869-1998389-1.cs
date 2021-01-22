    struct tcp_keepalive
    {
    	public int OnOff;
    	public int KeepAliveTime;
    	public int KeepAliveInterval;
    	public unsafe byte[] Buffer
    	{
    		get
    		{
    			var buf = new byte[Marshal.SizeOf(typeof(tcp_keepalive))];
    			fixed(void* p = &this) Marshal.Copy(new IntPtr(p), buf, 0, buf.Length);
    			return buf;
    		}
    	}
    };
    static void KeepAliveTest()
    {
    	using(var c = new TcpClient())
    	{
    		c.Connect("www.google.com", 80);
    		var s = c.Client;
    		var ka = new tcp_keepalive();
    		ka.OnOff = 1; // enable
    		ka.KeepAliveTime = 1000 * 60; // 60 seconds of inactivity allowed
    		ka.KeepAliveInterval = 1000; // 1 second interval on keep-alive checks (default)
    		s.IOControl(IOControlCode.KeepAliveValues, ka.Buffer, null);
    		var ns = c.GetStream();
    		Console.WriteLine("Connected to " + s.RemoteEndPoint);
    		while(true)
    		{
    			SocketError se;
    			s.Blocking = false;
    			s.Receive(new byte[0], 0, 0, SocketFlags.Peek, out se);
    			s.Blocking = true;
    			if(!s.Connected)
    			{
    				// se==SocketError.ConnectionReset||SocketError.NetworkReset if the connection was closed because of a keep-alive check
    				Console.WriteLine("Socket disconnected: " + se);
    				break;
    			}
    			// do other stuff
    			if(ns.DataAvailable) ns.Read(new byte[100], 0, 100);
    			else Thread.Sleep(10);
    		}
    	}
    }
