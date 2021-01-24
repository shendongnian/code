            public void Configure(IHostApplicationLifetime appLifetime)
            {
                appLifetime.ApplicationStarted.Register(() =>
                {
                    Console.WriteLine("Press Ctrl+C to shut down.");
                });
    
                appLifetime.ApplicationStopped.Register(() =>
                {
                    Console.WriteLine("Shutting down...");
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                });
            }
