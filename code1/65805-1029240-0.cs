    using System;
    using System.Timers;
    static class Program {
        static void Main() {
            using (Timer timer = new Timer()) {
                timer.Interval = 2000;
                timer.Elapsed += delegate {
                    Console.Error.WriteLine("tick");
                };
                timer.Start();
                Console.WriteLine("Press [ret] to exit");
                Console.ReadLine();
                timer.Stop();
            }
        }
    }
