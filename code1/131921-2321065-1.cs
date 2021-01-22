    class Program
    {
        static TimeSpan _timeSpan = new TimeSpan(0, 0, 5);
        static ManualResetEvent _stop = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Console.TreatControlCAsInput = false;
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
            { 
                _stop.Set();
                e.Cancel = true;
            };
            while (!_stop.WaitOne(_timeSpan))
            {
                Console.WriteLine("Waiting...");
            }
            Console.WriteLine("Done.");
        }
    }
