    class SocketMutex{
		private Socket _sock;
		private IPEndPoint _ep;
		public SocketMutex(){
			_ep = new IPEndPoint(IPAddress.Parse( "127.0.0.1" ), 7177);
			_sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			_sock.ExclusiveAddressUse = true;  // most critical if you want this to be a system wide mutex
		}
		public bool IsSingleInstance(){
			try{		
				_sock.Bind(_ep); // 'SocketException: Address already in use'
			}catch(SocketException se){
				Console.Error.WriteLine ("SocketMutex Exception: " se.Message);
				return false;
			}
			return true;
		
		}
	}
