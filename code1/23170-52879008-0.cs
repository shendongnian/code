            ServerSocket = new TcpListener(endpoint);
            try
            {
                ServerSocket.Start();
                ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);
                ServerStarted = true;
                Console.WriteLine("Server has successfully started.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server was unable to start : {ex.Message}");
                return false;
            }
