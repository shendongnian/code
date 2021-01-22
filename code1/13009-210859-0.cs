    static void Main(string[] args)
            {
                System.Timers.Timer timer = new System.Timers.Timer(60000);
                timer.Elapsed += new System.Timers.ElapsedEventHandler(T_Elapsed);
                timer.Start();
                var i = Console.ReadLine();
                if (string.IsNullOrEmpty(i)) 
                {
                    timer.Stop();
                    Console.WriteLine("{0}", i);
                }
            }
    
            static void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Console.WriteLine("Defult Values Used");
                var T = (Timer)sender;
                T.Stop;
    
            }
