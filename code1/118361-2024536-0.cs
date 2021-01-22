    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApplication19 {
        class Program {
    
            static object sync = new object(); 
    
            static void Main(string[] args) {
                int counter = 0; 
                ThreadPool.QueueUserWorkItem(new WaitCallback((_) => ThreadProc(ref counter)), null);
    
                while (true) {
                    lock (sync) {
                        if (counter == 1) break;
                    }    
                    Thread.Sleep(1); 
                }
    
                Console.Write(counter);
                Console.Read();
    
            }
    
            static void ThreadProc(ref int counter) {
                lock (sync) {
                    counter++;
                }
            }
        }
    }
