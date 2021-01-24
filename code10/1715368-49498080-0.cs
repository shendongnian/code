	var client = new NamedPipeClientStream(Environment.MachineName, "TestPipes");
	client.Connect();
	Console.WriteLine($"Connection esteblished at {DateTime.Now}, you may continue");
	StreamWriter writer = new StreamWriter(client);
	while (true)
	{
		StreamReader reader = new StreamReader(client);
		string input = Console.ReadLine();
		if (String.IsNullOrEmpty(input)) continue;
		writer.WriteLine(input);
		writer.Flush();
		string serverString;
		while (reader.Peek() >= 0)
		{
			serverString = reader.ReadLine();
			Console.WriteLine(serverString);
		}
	}
