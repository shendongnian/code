    using System;
    using System.Windows.Forms;
    class Program
    {
        static void Main()
        {
            var timer = new Timer();
            var startTime = DateTime.Now;
            timer.Interval = 5000;
            timer.Tick += (s, e) =>
            {
                Console.WriteLine("Hi!");
                if (DateTime.Now - startTime > new TimeSpan(0, 1, 0))
                {
                    Application.Exit();
                }
            };
            timer.Start();
            Application.Run();
        }
    }
