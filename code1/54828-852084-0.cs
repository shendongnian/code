    void ThreadStart()
    {
        if (!running)
        {
            listener.Start();
            running = true;
            lock (sync)
            {
                while (running)
                {
                    try
                    {
                        Console.WriteLine("BeginAccept [{0}]", 
                            Thread.CurrentThread.ManagedThreadId);
                        listener.BeginAcceptTcpClient(new AsyncCallback(Accept), listener);
                        Console.WriteLine("Wait [{0}]", 
                            Thread.CurrentThread.ManagedThreadId);
                        Monitor.Wait(sync);  // Release lock and wait for a pulse
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
    
    void Accept(IAsyncResult result)
    {
        // Let the server continue listening
        lock (sync)
        {
            Console.WriteLine("Pulse [{0}]", 
                Thread.CurrentThread.ManagedThreadId);
            Monitor.Pulse(sync);
        }
        if (running)
        {
            TcpListener localListener = (TcpListener)result.AsyncState;
            using (TcpClient client = localListener.EndAcceptTcpClient(result))
            {
                handler.Handle(client.GetStream());
            }
        }
    }
