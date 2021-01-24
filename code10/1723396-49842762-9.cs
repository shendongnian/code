	static void RunServer()
	{
		using (var pipeServer = new NamedPipeServerStream("TestPipe", PipeDirection.InOut))
		{
			using (var reader = new StreamReader(pipeServer))
			{
			    using (var writer = new StreamWriter(pipeServer))
				{
					var running = true;
					Console.WriteLine("Server is waiting for a client");
					pipeServer.WaitForConnection();
					Console.WriteLine("Server has connection from client");
					Console.WriteLine("Server: Saying Hi");
					writer.WriteLine("Hello!");
					Console.WriteLine("Server: Prompting for Input");
					writer.WriteLine("Do you accept (y/n):");
					writer.Flush();
					while(running) 
					{
						pipeServer.WaitForPipeDrain();
						var message = reader.ReadLine();
						Console.WriteLine("Server: Recieved from client {0}", message);
						if (message.Equals("quit")) 
						{
							writer.WriteLine("quit");
							running = false;
						}
					} 
				}
			}
		}
		Console.WriteLine("Server Quits");
	}
