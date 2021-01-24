        public static async Task Main(string[] args)
        {
            Console.WriteLine("You have 10 seconds to press the Y key...");
            var cts = new CancellationTokenSource(10_000);
            try
            {
                while (true)
                {
                    var key = await ReadKeyAsync(cts.Token);
                    if (key.Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("Good job!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Key");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.Write("Time up!");
            }
        }
