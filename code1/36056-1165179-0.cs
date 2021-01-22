    sock = new Socket( AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP );
	sock.Bind( new IPEndPoint( IPAddress.Parse( "10.25.2.148" ), 0 ) );
	sock.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, 1 );	
	byte[] trueBytes = new byte[] { 1, 0, 0, 0 };
	byte[] outBytes = new byte[] { 0, 0, 0, 0 };
	sock.IOControl( IOControlCode.ReceiveAll, trueBytes, outBytes );
	sock.BeginReceive( data, 0, data.Length, SocketFlags.None, new AsyncCallback( OnReceive ), null );
