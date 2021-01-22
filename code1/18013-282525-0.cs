    using System;
    using System.Diagnostics;
    using System.Text;
    
    public class Test
    {
        const int Limit = 4000000;
        
        static void Main()
        {
            Time(Concatenation, "Concat");
            Time(SimpleStringBuilder, "StringBuilder as in post");
            Time(SimpleStringBuilderNoToString, "StringBuilder calling Append(i)");
            Time(CapacityStringBuilder, "StringBuilder with appropriate capacity");
        }
        
        static void Time(Action action, string name)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            Console.WriteLine("{0}: {1}ms", name, sw.ElapsedMilliseconds);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        
        static void Concatenation()
        {
            int i = 1;
            string fraction = "";
            while (fraction.Length < Limit)
            {
                // concatenating strings is much faster for small strings
                string tmp = "";
                for (int j = 0; j < 1000; j++)
                {
                    tmp += i.ToString();
                    i++;
                }
                fraction += tmp;            
            }
        }
        
        static void SimpleStringBuilder()
        {
            int i = 1;
            StringBuilder fraction = new StringBuilder();
            while (fraction.Length < Limit)
            {
                fraction.Append(i.ToString());
                i++;
            }
        }
    
        static void SimpleStringBuilderNoToString()
        {
            int i = 1;
            StringBuilder fraction = new StringBuilder();
            while (fraction.Length < Limit)
            {
                fraction.Append(i);
                i++;
            }
        }
    
        static void CapacityStringBuilder()
        {
            int i = 1;
            StringBuilder fraction = new StringBuilder(Limit + 10);
            while (fraction.Length < Limit)
            {
                fraction.Append(i);
                i++;
            }
        }
    }
