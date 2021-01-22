    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Diagnostics;
    
    namespace SO1215227
    {
        public class Program
        {
            public static void Main()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var list1 = Sequence(1, 100);
                var list2 = Sequence(101, 200);
                var list3 = Sequence(201, 300);
                sw.Stop();
                Console.Out.WriteLine("sequential: " + sw.ElapsedMilliseconds + " ms");
                sw.Reset();
    
                Func<Int32, Int32, List<Int32>> listProducer = Sequence;
                sw.Start();
                var list1Background = listProducer.BeginInvoke(1, 100, null, null);
                var list2Background = listProducer.BeginInvoke(101, 200, null, null);
                var list3Background = listProducer.BeginInvoke(201, 300, null, null);
                
                list1 = listProducer.EndInvoke(list1Background);
                list2 = listProducer.EndInvoke(list2Background);
                list3 = listProducer.EndInvoke(list3Background);
                sw.Stop();
                Console.Out.WriteLine("parallel: " + sw.ElapsedMilliseconds + " ms");
    
                Console.Out.Write("Press enter to exit...");
                Console.In.ReadLine();
            }
    
            private static List<Int32> Sequence(Int32 from, Int32 to)
            {
                List<Int32> result = new List<Int32>();
                for (Int32 index = from; index <= to; index++)
                {
                    result.Add(index);
                    Thread.Sleep(10); // simulate I/O wait
                }
                return result;
            }
        }
    }
