        static void Listeners()
        {
            using (Socket socketForClient = tcpListener.AcceptSocket())
            {
                if (socketForClient.Connected)
                {
                    Console.WriteLine("Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
                    using (NetworkStream networkStream = new NetworkStream(socketForClient))
                    using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream))
                    using (System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream))
                    {
                        try
                        {
                            while (true)
                            {
                                string theString = streamReader.ReadLine();
                                Console.WriteLine("Message recieved by client:" + theString);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }
            Console.WriteLine("Press any key to exit from server program");
            Console.ReadKey();
        }
