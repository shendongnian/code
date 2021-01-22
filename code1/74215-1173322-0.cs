        static void TimerTest()
        {
            using (Timer t = new Timer(200))
            {
                t.Start();
                t.Elapsed += new ElapsedEventHandler(t_Elapsed);
                System.Threading.Thread.Sleep(5000); // Do some work here.
            }
            System.Threading.Thread.Sleep(5000); // Wait before closing the application
        }
        static void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello.");
        }
