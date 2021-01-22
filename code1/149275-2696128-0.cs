    using System;
    using System.Threading;
    class Program
    {
        static void Main()
        {
            bool isCompleted = false;
            int diceRollResult = 0;
            // AutoResetEvent is one type of the WaitHandle that you can use for signaling purpose.
            AutoResetEvent waitHandle = new AutoResetEvent(false);
            Thread thread = new Thread(delegate() {
                Random random = new Random();
                int numberOfTimesToLoop = random.Next(1, 10);
                for (int i = 0; i < numberOfTimesToLoop - 1; i++) {
                    diceRollResult = random.Next(1, 6);
                    // Signal the waiting thread so that it knows the result is ready.
                    waitHandle.Set();
                    // Sleep so that the waiting thread have enough time to get the result properly - no race condition.
                    Thread.Sleep(1000);
                }
                diceRollResult = random.Next(1, 6);
                isCompleted = true;
                // Signal the waiting thread so that it knows the result is ready.
                waitHandle.Set();
            });
            thread.Start();
            while (!isCompleted) {
                // Wait for signal from the dice rolling thread.
                waitHandle.WaitOne();
                Console.WriteLine("Dice roll result: {0}", diceRollResult);
            }
            Console.Write("Dice roll completed. Press any key to quit...");
            Console.ReadKey(true);
        }
    }
