        class SecondThreadConcern
        {
            public static void LongWork(IProgress<string> progress)
            {
                // Perform a long running work...
                for (var i = 0; i < 10; i++)
                {
                    Task.Delay(500).Wait();
                    progress.Report(i.ToString());
                }
            }
        }
