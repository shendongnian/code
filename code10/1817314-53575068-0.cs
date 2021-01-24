        public static async Task<ConsoleKeyInfo> ReadKeyAsync(CancellationToken cancellationToken)
        {
            while (!Console.KeyAvailable)
            {
                await Task.Delay(100, cancellationToken);
            }
            return Console.ReadKey();
        }
