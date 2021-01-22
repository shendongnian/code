    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace ConsoleApplication3
    {
        class MyClass
        {
            double foo = 1.23;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MyClass myobj = new MyClass();
                int n = 10000000;
    
                Stopwatch sw = Stopwatch.StartNew();
    
                for (int i = 0; i < n; i++)
                {
                    bool b = myobj.GetType() == typeof(MyClass);
                }
    
                sw.Stop();
                Console.WriteLine("Time for Type-Comparison: " + GetElapsedString(sw));
    
                sw = Stopwatch.StartNew();
    
                for (int i = 0; i < n; i++)
                {
                    bool b = myobj is MyClass;
                }
    
                sw.Stop();
                Console.WriteLine("Time for Is-Comparison: " + GetElapsedString(sw));
            }
    
            public static string GetElapsedString(Stopwatch sw)
            {
                TimeSpan ts = sw.Elapsed;
                return String.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
        }
    }
