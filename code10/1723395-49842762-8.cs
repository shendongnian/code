	static void RunClient()
	{
		using (var pipeClient = new NamedPipeClientStream(".", "TestPipe", PipeDirection.InOut))
		{
			Console.WriteLine("Client is waiting to connect");
	   		if(!pipeClient.IsConnected){pipeClient.Connect();}
			Console.WriteLine("Client is connected");
			using (var reader = new StreamReader(pipeClient))
			{
			    using (var writer = new StreamWriter(pipeClient))
				{
					var running = true;
					while(running) 
					{
						Console.WriteLine("Client is waiting for input");
						var message = reader.ReadLine();
						if (message != null)
						{
							Console.WriteLine("Client: Recieved from server {0}", message);
							switch (message)
							{
								case "Do you accept (y/n):":
									writer.WriteLine("y");
									writer.WriteLine("quit");
									writer.Flush();
									break;
								case "quit": 
									running = false; 
									break;
							}
						}
					} 
				}
			}
		}
		Console.WriteLine("Client Quits");
	}
