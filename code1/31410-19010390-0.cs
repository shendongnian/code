    using System;
    using System.Diagnostics;
    class Test
    {
        const int Size = 30000000;
        static void Main()
        {
            object[] values = new object[Size];
            for (int i = 0; i < Size; i++)
            {
                values[i] = "x";
            }
            FindLengthWithIsAndCast(values);
            FindLengthWithIsAndAs(values);
            FindLengthWithAsAndNullCheck(values);
        
            FindLengthWithCast(values);
            FindLengthWithAs(values);
            Console.ReadLine();
        }
        static void FindLengthWithIsAndCast(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int len = 0;
            foreach (object o in values)
            {
                if (o is string)
                {
                    string a = (string)o;
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
        static void FindLengthWithCast(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int len = 0;
            foreach (object o in values)
            {
                string a = (string)o;
                len += a.Length;
            }
            sw.Stop();
            Console.WriteLine("Cast: {0} : {1}", len,
                              (long)sw.ElapsedMilliseconds);
        }
        static void FindLengthWithAs(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int len = 0;
            foreach (object o in values)
            {
                string a = o as string;
                len += a.Length;
            }
            sw.Stop();
            Console.WriteLine("As: {0} : {1}", len,
                              (long)sw.ElapsedMilliseconds);
        }
    }
