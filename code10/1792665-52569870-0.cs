	foreach(int s in Ports)
	{
		using (TcpClient Scan = new TcpClient())
		{
			try
			{
				Scan.Connect(IP, s);
				Console.WriteLine($"[{s}] | OPEN", Color.Green);
			}
			catch
			{
				Console.WriteLine($"[{s}] | CLOSED", Color.Red);
			}
		}
	}
