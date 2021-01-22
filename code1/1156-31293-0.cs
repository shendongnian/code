    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ObjectInitSpeedTest
    {
       class Program
       {
           //Note: don't forget to build it in Release mode.
           static void Main()
           {
               normalSpeedTest();           
               parallelSpeedTest();
    
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("Press a key ...");
               Console.ReadKey();
           }
    
           private static void parallelSpeedTest()
           {
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("parallelSpeedTest");
    
               long totalObjectsCreated = 0;
               long totalElapsedTime = 0;
    
               var tasks = new List<Task>();
               var processorCount = Environment.ProcessorCount;
    
               Console.WriteLine("Running on {0} cores", processorCount);
    
               for (var t = 0; t < processorCount; t++)
               {
                   tasks.Add(Task.Factory.StartNew(
                   () =>
                   {
                       const int reps = 1000000000;
                       var sp = Stopwatch.StartNew();
                       for (var j = 0; j < reps; ++j)
                       {
                           new object();
                       }
                       sp.Stop();
    
                       Interlocked.Add(ref totalObjectsCreated, reps);
                       Interlocked.Add(ref totalElapsedTime, sp.ElapsedMilliseconds);
                   }
                   ));
               }
    
               // let's complete all the tasks
               Task.WaitAll(tasks.ToArray());
    
               Console.WriteLine("Created {0:N} objects in 1 sec\n", (totalObjectsCreated / (totalElapsedTime / processorCount)) * 1000);
           }
    
           private static void normalSpeedTest()
           {
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("normalSpeedTest");
    
               const int reps = 1000000000;
               var sp = Stopwatch.StartNew();
               sp.Start();
               for (var j = 0; j < reps; ++j)
               {
                   new object();
               }
               sp.Stop();
    
               Console.WriteLine("Created {0:N} objects in 1 sec\n", (reps / sp.ElapsedMilliseconds) * 1000);
           }
       }
    }
