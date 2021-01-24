    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
     
    namespace ConsoleApplication1
    {
        class Program
        {
            public static List<Stopwatch> sws = new List<Stopwatch>();
            public static List<Thread> threads = new List<Thread>();
     
            static void Main()
            {
                for (var i = 0; i < 300; i++)
                {               
                    threads.Add(new Thread(Dummy));
                    sws.Add(new Stopwatch());
                }
                            
                for(int i = 0; i < 300; i++) sws[i].Start();
     
                new Thread( () => { for(int i = 0; i < 5; i++) threads[i].Start(i); }).Start();
                new Thread( () => { for(int i = 5; i < 10; i++) threads[i].Start(i); }).Start();
                new Thread( () => { for(int i = 10; i < 15; i++) threads[i].Start(i); }).Start();
                new Thread( () => { for(int i = 15; i < 20; i++) threads[i].Start(i); }).Start();
                new Thread( () => { for(int i = 20; i < 25; i++) threads[i].Start(i); }).Start();
                new Thread( () => { for(int i = 25; i < 30; i++) threads[i].Start(i); }).Start();
                new Thread( () => { for(int i = 30; i < 35; i++) threads[i].Start(i); }).Start();
                new Thread( () => { for(int i = 35; i < 40; i++) threads[i].Start(i); }).Start();
                
                Console.Read();
            }
     
            static void Dummy(object data)
            {
                int i = (int)data;
                Thread.Sleep(250); 
                sws[i].Stop();
                Console.WriteLine(sws[i].ElapsedMilliseconds.ToString());
            }
        }
    }     
