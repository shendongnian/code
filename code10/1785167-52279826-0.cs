    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;
    using System.Threading.Tasks;
    namespace Sandbox
    {
        public interface IDataProcesser
        {
            TOut Process<TIn, TOut>(TIn input);
        }
        public interface IDataProcesser2<TIn, TOut>
        {
            TOut Process(TIn input);
        }
        class Class1 : IDataProcesser
        {
            public TOut Process<Tin, TOut>(Tin input)
            {
                return default(TOut);
            }
        }
        class Class2 : IDataProcesser2<int, long>
        {
            public long Process(int input)
            {
                return default(long);
            }
        }
        class Program
        {
            private static int _loopCount = 1000000000;
            static void Main(string[] args)
            {
                var warmupEquals = false;
                var equals1 = false;
                var equals2 = false;
               
                for (long i = 0; i < _loopCount; i++)
                {
                    Class1 warmup = new Class1();
                    var w1 = warmup.Process<int, long>(default(int)) == 0;
                    warmupEquals = w1;
                }
                var sw = new Stopwatch();
                sw.Start();
                for (long i = 0; i < _loopCount; i++)
                {
                    Class1 c1 = new Class1();
                    var t1 = c1.Process<int, long>(default(int)) == 0;
                    if (t1)
                    {
                        equals1 = true;
                    }
                }
                sw.Stop();
                Console.WriteLine("Method 1");
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Restart();
                sw.Start();
                for (long i = 0; i < _loopCount; i++)
                {
                    Class2 c2 = new Class2();
                    var t2 = c2.Process(default(int)) == 0;
                    if (t2)
                    {
                        equals2 = true;
                    }
                }
                sw.Stop();
                Console.WriteLine("Method 2");
                Console.WriteLine(sw.ElapsedMilliseconds);
                Console.WriteLine(warmupEquals);
                Console.WriteLine(equals1);
                Console.WriteLine(equals2);
                Console.ReadLine();
            }
        }
    }
