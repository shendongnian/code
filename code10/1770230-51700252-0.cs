    using System;
    using System.Net;
    using System.Timers;
    
    static void Main(string[] args)
            {
                Console.WriteLine("The system is start at {0}", DateTime.Now);
                Timer t = new Timer(10000);
                t.Enabled = true;
                t.Elapsed += T_Elapsed;
                Console.ReadKey();
                
            }
            private static void T_Elapsed(object sender, ElapsedEventArgs e)
            {
                //write your code
            }
