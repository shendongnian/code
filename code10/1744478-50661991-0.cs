    using System.Timers;
    //...
    class Program
    {
        private static Timer MainTimer = new Timer(1000 * 60 * 60);
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for insertion in batch");
            MainTimer.Elapsed += MainTimer_Elapsed;
            // Wait for the start of the hour. Then start the one-hour MainTimer. 
            var tmptimer = new Timer() { Interval = 1000 };
            tmptimer.Elapsed += (sender, e) =>
            {
                if (DateTime.Now.Minute == 0)
                {
                    MainTimer.Start();              
                    tmptimer.Stop();
                    MainTimer_Elapsed(null, null);  // Call manually first time 
                }
            };
            tmptimer.Start();
            while (true)
                Console.Read();
        }
        private static void MainTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection ("Server=localhost\\SQLEXPRESS;Database=VIDEOJUEGOS;Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_virtualX", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine("Successful insertion");
                    }
                }
            }
            Console.WriteLine("Waiting for insertion in batch");
            GC.Collect();
        }
    }
   
