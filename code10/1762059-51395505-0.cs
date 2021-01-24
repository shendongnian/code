            var cancelled = new ManualResetEvent(false);
            Console.CancelKeyPress += (s, e) =>
            {
                e.Cancel = true;
                Console.WriteLine("Ctrl+C detected...");
                cancelled.Set();
            };
            Console.WriteLine("Running. The only thing to do now is ctrl+c or close the window...");
            WaitHandle.WaitAny(new[] { cancelled });
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
