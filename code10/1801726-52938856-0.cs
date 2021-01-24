    List<TcpClient> connections = new List<TcpClient>();
    public async Task WaitForConnectionsAsync()
    {
            await (waitinfConnectionTaks = Task.Factory.StartNew(async () =>
            {
               //REMOVED LOOP
               // while (!waitingForConnectionsToken.IsCancellationRequested)
                {
                    foreach (var listener in networkListeners)
                    {
                        if (waitingForConnectionsToken.IsCancellationRequested) break;
                        if (!listener.Active)
                        {
                            continue;
                        }
                        if (listener.Pending())
                        {
                            try
                            {
                                TcpClient connection = await listener.AcceptTcpClientAsync();
                                
                                //RETAIN CONNECTIONS IN A LIST
                                connections.Add(connection);
                            }
                            catch (ObjectDisposedException x)
                            {
                                Write.Error(x.ToString());
                            }
                        }
                    }
                }
            }));
            //ITERATE OVER CONNECTIONS
            foreach (var connection in connections)
            {
                //INVOKE EVENT
                OnPendingConnection?.Invoke(this, connection);
            }
            //CLEAR THE LIST
            connections.Clear();
            //RESTART THE TASK
            if(!waitingForConnectionsToken.IsCancellationRequested)
               WaitForConnectionsAsync();
        }
