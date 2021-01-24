	//using System.Threading.Tasks;
	//using System.IO.Pipes;
	
	static void Main()
	{
	    var server = Task.Factory.StartNew(() => RunServer());
	    var client = Task.Factory.StartNew(() => RunClient());
	    Task.WaitAll(server, client);
	    Console.WriteLine("Done");
	}
	
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
					var message = string.Empty;
	                var running = true;
	                while(running) 
	                {
	                    Console.WriteLine("Client is waiting for input");
	                    var chr = reader.Read();
	                    if (chr >= 32)
	                    {
							message = message + (char)chr;
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
						else {
							message = string.Empty;
							Console.WriteLine("Client: New Line Received from Server");
						}
	                } 
	            }
	        }
	    }
	    Console.WriteLine("Client Quits");
	}
	
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
	                writer.Write("Do you accept (y/n):"); //NB: This is a write, not a write line!
	                writer.Flush();
	                while(running) 
	                {
	                    pipeServer.WaitForPipeDrain();
	                    var message = reader.ReadLine();
	                    Console.WriteLine("Server: Recieved from client {0}", message);
	                    switch (message)
						{
							case "quit":  
		                        writer.WriteLine("quit");
		                        running = false;
								break;
							default:
								writer.WriteLine("");
								break;
	                	} 
					}
	            }
	        }
	    }
	    Console.WriteLine("Server Quits");
	}
