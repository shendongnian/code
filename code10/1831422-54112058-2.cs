    using System;
    using System.Timers;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Declare the counter somewhere
                var counter = 0;
                // Create timer
                var delayTimer = new Timer
                {
                    Interval = 5000, // Changed to 5 seconds for demo purposes 
                    AutoReset = true,
                };
                // Create the event handler
                delayTimer.Elapsed += ((o, e) =>
                {
                    // Print counter value before resetting
                    Console.WriteLine($"[Timer elapsed] The counter has value {counter}, resetting it...");
                    counter = 0;
                });
                // Start the timer
                delayTimer.Start();
                // Now simulate doing other stuff while the timer is running...
                Console.WriteLine("I'll be silently incrementing the counter at a random pace.");
                Console.WriteLine("Every five seconds, the timer event handler will reset the counter " +
                                  "right after telling you how far I got.");
                var r = new Random();
                while (true)
                {
                    // Sleep for a random number of milliseconds (between 0 and 999)
                    var sleepLength = r.Next() % 1000;
                    System.Threading.Thread.Sleep(sleepLength);
                    // Increment the counter
                    counter++;
                }
                // Console output example (values will be random): 
                // I'll be silently incrementing the counter at a random pace.
                // Every five seconds, the timer event handler will reset the counter right after telling you how far I got.
                // [Timer elapsed] The counter has value 11, resetting it...
                // [Timer elapsed] The counter has value 9, resetting it...
                // [Timer elapsed] The counter has value 12, resetting it...
                // [Timer elapsed] The counter has value 10, resetting it...
                // [Timer elapsed] The counter has value 9, resetting it...
                // [Timer elapsed] The counter has value 8, resetting it...
                // [Timer elapsed] The counter has value 6, resetting it...
                // [Timer elapsed] The counter has value 4, resetting it...
                // [Timer elapsed] The counter has value 14, resetting it...
            }
        }
    }
