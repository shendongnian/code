        private async Task Listening()
        {
            while (true)
            {
                var listener = new TcpListener(IPAddress.Any, Port);
                try
                {
                    listener.Start();
                    Console.ResetColor();
                    Console.WriteLine($"Genji server started at http://localhost:{Port}/");
                    while (true)
                    {
                        var tcp = await listener.AcceptTcpClientAsync();
                        var stream = tcp.GetStream();
                        Excute(stream).GetAwaiter();
                    }
                }
                catch (Exception e)
                {
                    Recorder.RecordException(e);
                    listener.Stop();
                    await Task.Delay(5000);
                }
            }
        }
        private async Task Excute(NetworkStream stream)
        {
            Recorder.RecordIncoming();
            try
            {
                await Calculate(stream);
            }
            catch (RequestTerminatedException)
            {
                Recorder.Print("A request was terminated!");
            }
            catch (Exception e)
            {
                stream.Dispose();
                Recorder.RecordException(e);
            }
        }
