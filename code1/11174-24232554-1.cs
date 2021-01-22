    using System;
    using System.Timers;
    
    namespace TimerExample
    {
        class Program
        {
            static Timer timer = new Timer(1000);
            static int i = 10;
    
            static void Main(string[] args)
            {            
                timer.Elapsed+=timer_Elapsed;
                timer.Start(); Console.Read();
            }
    
            private static void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                i--;
    
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine("                  DEFUSE THE BOMB");
                Console.WriteLine(""); 
                Console.WriteLine("                Time Remaining:  " + i.ToString());
                Console.WriteLine("");        
                Console.WriteLine("=================================================");
    
                if (i == 0) 
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("==============================================");
                    Console.WriteLine("         B O O O O O M M M M M ! ! ! !");
                    Console.WriteLine("");
                    Console.WriteLine("               G A M E  O V E R");
                    Console.WriteLine("==============================================");
    
                    timer.Close();
                    timer.Dispose();
                }
    
                GC.Collect();
            }
        }
    }
