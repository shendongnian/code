        static Task<string> ReadLineAsync(CancellationToken cancellation)
        {
            return Task.Run(() =>
            {
                while (!Console.KeyAvailable)
                {
                    if (cancellation.IsCancellationRequested)
                        return null;
                    Thread.Sleep(100);
                }
                return Console.ReadLine();
            });
        }
