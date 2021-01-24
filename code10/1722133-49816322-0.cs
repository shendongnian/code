    class TryEnterIssue
    {
        public static bool ClientDisconnected = false;
        static void Main(string[] args)
        {
            var cfg = new IgniteConfiguration() { ... };
            using (var ignite = Ignition.Start(cfg))
            {
                ...
                ICache<int, string> cache = ignite.GetOrCreateCache<int, string>(cacheConfiguration);
                ignite.ClientDisconnected += (sender, eventArgs) =>
                {
                    ClientDisconnected = true;
                    Console.WriteLine("Client disconnected.");
                };
                ignite.ClientReconnected += (sender, eventArgs) =>
                {
                    ClientDisconnected = false;
                    Console.WriteLine("Client reconnected.");
                };
                ...
                ICacheLock lock1 = cache.Lock(1);
                try
                {
                    if (!lock1.TryEnter())
                    {
                        if (ClientDisconnected)
                        {
                            // Client is disconnected.
                        }
                        else
                        {
                            // Unable to acquire a lock.
                        }
                    }
                    else
                    {
                        lock1.Exit();
                    }
                }
                catch (Exception e)
                {
                    ...
                }
                ...
            }
        }
    }
