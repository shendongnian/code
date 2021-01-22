    using System;
    using System.Diagnostics;
    using System.Linq;
    
    class Test
    {
        const int Size = 30000000;
    
        static void Main()
        {
            object[] values = new object[Size];
            for (int i = 0; i < Size - 2; i += 3)
            {
                values[i] = null;
                values[i + 1] = "x";
                values[i + 2] = new object();
            }
            FindLengthWithIsAndCast(values);
            FindLengthWithIsAndAs(values);
            FindLengthWithAsAndNullCheck(values);
        }
    
        static void FindLengthWithIsAndCast(object[] values)        
        {
            Stopwatch sw = Stopwatch.StartNew();
            int len = 0;
            foreach (object o in values)
            {
                if (o is string)
                {
                    string a = (string) o;
                    len += a.Length;
                }
            }
            sw.Stop();
            Console.WriteLine("Is and Cast: {0} : {1}", len,
                              (long)sw.ElapsedMilliseconds);
        }
    
        static void FindLengthWithIsAndAs(object[] values)        
        {
            Stopwatch sw = Stopwatch.StartNew();
            int len = 0;
            foreach (object o in values)
            {
                if (o is string)
                {
                    string a = o as string;
                    len += a.Length;
                }
            }
            sw.Stop();
            Console.WriteLine("Is and As: {0} : {1}", len,
                              (long)sw.ElapsedMilliseconds);
        }
    
        static void FindLengthWithAsAndNullCheck(object[] values)        
        {
            Stopwatch sw = Stopwatch.StartNew();
            int len = 0;
            foreach (object o in values)
            {
                string a = o as string;
                if (a != null)
                {
                    len += a.Length;
                }
            }
            sw.Stop();
            Console.WriteLine("As and null check: {0} : {1}", len,
                              (long)sw.ElapsedMilliseconds);
        }
    }
