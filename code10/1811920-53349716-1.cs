            static int prod;
            public static void Main(string[] args)
            {
                Task running  = Task.Run(async () => { await AsyncMultiply(2, 3); });
    
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(i + " ");
                    Thread.Sleep(100);
                }
    
                running.Wait(); // Freeze thread and wait for task.
                
    
                Console.WriteLine();
                Console.WriteLine("Prod = " + prod);
    
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey();
            }
    
            public static async Task DoSomethingAsync()
            {
                await Task.Delay(100);
            }
    
            public static async Task<int> AsyncMultiply(int a, int b)
            {
                Thread.Sleep(2000);
                prod = a * b;
                return prod;
            }
