		public static bool TryPortNumber(int port)
		{
			try
			{
				using (var client = new System.Net.Sockets.TcpClient(new System.Net.IPEndPoint(System.Net.IPAddress.Any, port)))
				{
					return true;
				}
			}
			catch (System.Net.Sockets.SocketException error)
			{
				if (error.SocketErrorCode == System.Net.Sockets.SocketError.AddressAlreadyInUse /* check this is the one you get */ )
					return false;
				/* unexpected error that we DON'T have handling for here */
				throw error;
			}
		}
