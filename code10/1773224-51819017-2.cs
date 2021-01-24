    using System;
    using Test;
    
    namespace teste
    {
       static class MainClass{
          
            public static void PrintCounters(Counter[] counters)
            {
                foreach (Counter c in counters)
                {
                    **string name = c.Name;**
                    **int value = c.Value;**
    
                    Console.WriteLine("{0} is {1}", name, value);
                }
            }
       }
        class Program
        {
            static void Main(string[] args)
            {
               
                Counter[] myCounters = new Counter[3];
    
                myCounters[0] = new Counter("Counter 1");
                myCounters[1] = new Counter("Counter 2");
                myCounters[2] = myCounters[0];
    
                for (int i = 0; i < 4; i++) {
                  
                  **myCounters[0].Increment();**
                }
                for (int i = 0; i < 9; i++) {
                  
                  **myCounters[1].Increment();**
                }
                
                **MainClass.PrintCounters(myCounters);**
                **myCounters[2].Reset();**
                **MainClass.PrintCounters(myCounters);**
            }
        }
    }
