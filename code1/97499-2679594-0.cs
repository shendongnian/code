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
                values[i + 1] = "";
                values[i + 2] = 1;
            }
    
            FindSumWithCast(values);
            FindSumWithAsAndHas(values);
            FindSumWithAsAndIs(values);
    
            
            FindSumWithIsThenAs(values);
            FindSumWithIsThenConvert(values);
    
            FindSumWithLinq(values);
            
    
    
            Console.ReadLine();
        }
    
        static void FindSumWithCast(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            foreach (object o in values)
            {
                if (o is int)
                {
                    int x = (int)o;
                    sum += x;
                }
            }
            sw.Stop();
            Console.WriteLine("Cast: {0} : {1}", sum,
                              (long)sw.ElapsedMilliseconds);
        }
    
        static void FindSumWithAsAndHas(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            foreach (object o in values)
            {
                int? x = o as int?;
                if (x.HasValue)
                {
                    sum += x.Value;
                }
            }
            sw.Stop();
            Console.WriteLine("As and Has: {0} : {1}", sum,
                              (long)sw.ElapsedMilliseconds);
        }
    
    
        static void FindSumWithAsAndIs(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            foreach (object o in values)
            {
                int? x = o as int?;
                if (o is int)
                {
                    sum += x.Value;
                }
            }
            sw.Stop();
            Console.WriteLine("As and Is: {0} : {1}", sum,
                              (long)sw.ElapsedMilliseconds);
        }
    
    
    
    
    
    
    
        static void FindSumWithIsThenAs(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            foreach (object o in values)
            {
                
                if (o is int)
                {
                    int? x = o as int?;
                    sum += x.Value;
                }
            }
            sw.Stop();
            Console.WriteLine("Is then As: {0} : {1}", sum,
                              (long)sw.ElapsedMilliseconds);
        }
    
        static void FindSumWithIsThenConvert(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            foreach (object o in values)
            {            
                if (o is int)
                {
                    int x = Convert.ToInt32(o);
                    sum += x;
                }
            }
            sw.Stop();
            Console.WriteLine("Is then Convert: {0} : {1}", sum,
                              (long)sw.ElapsedMilliseconds);
        }
    
    
    
        static void FindSumWithLinq(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int sum = values.OfType<int>().Sum();
            sw.Stop();
            Console.WriteLine("LINQ: {0} : {1}", sum,
                              (long)sw.ElapsedMilliseconds);
        }
    }
