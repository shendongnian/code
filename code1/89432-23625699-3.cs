        static System.Timers.Timer DummyTimer = null;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Main Thread Id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                DummyTimer = new System.Timers.Timer(1000 * 5); // 5 sec interval
                DummyTimer.Enabled = true;
                DummyTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnDummyTimerFired);
                DummyTimer.AutoReset = true;
                DummyTimer.Start();
                Console.WriteLine("Hit any key to exit");
                Console.ReadLine();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            return;
        }
        static void OnDummyTimerFired(object Sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            return;
        }
