            using (TcpClient tcpClient = new TcpClient())
            {
                Console.WriteLine("Connecting...");
                try
                {
                    tcpClient.Connect(smptServer, 25);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Connection error: {0}", e.Message);
                    return;
                }
                if (!tcpClient.Connected)
                {
                    Console.WriteLine("Unknown connection error...");
                    return;
                }
                // get stream
                NetworkStream networkStream = null;
                Console.WriteLine("Get stream...");
                try
                {
                    networkStream = tcpClient.GetStream();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Stream error: {0}", e.Message);
                    return;
                }
				finally
				{
					networkStream.Close();
					networkStream.Dispose();
					tcpClient.Close();
				}
				
				Console.WriteLine("Connection successfull...")
				
			}
			
		
