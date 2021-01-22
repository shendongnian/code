    class Program
	{
		static void Main(string[] args)
		{
			try
			{
				byte[] input = BitConverter.GetBytes(1);
				byte[] buffer = new byte[4096];
				Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
				s.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.91"), 0));
				s.IOControl(IOControlCode.ReceiveAll, input, null);
				int bytes = 0;
				do
				{
					bytes = s.Receive(buffer);
					if (bytes > 0)
					{
						Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
					}
				} while (bytes > 0);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
