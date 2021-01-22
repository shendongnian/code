    using System;
    using System.Diagnostics;
    
    class Program
    {
        const int Size = 30000000;
    
        static void Main(string[] args)
        {
            object[] values = new object[Size];
            for (int i = 0; i < Size - 2; i += 3)
            {
                values[i] = null;
                values[i + 1] = "";
                values[i + 2] = 1;
            }
    
            FindSumWithIsThenCast(values);
                
            FindSumWithAsThenHasThenValue(values);
            FindSumWithAsThenHasThenCast(values);
    
            FindSumWithManualAs(values);
            FindSumWithAsThenManualHasThenValue(values);
    
        
    
            Console.ReadLine();
        }
    
        static void FindSumWithIsThenCast(object[] values)
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
            Console.WriteLine("Is then Cast: {0} : {1}", sum,
                                (long)sw.ElapsedMilliseconds);
        }
    
        static void FindSumWithAsThenHasThenValue(object[] values)
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
            Console.WriteLine("As then Has then Value: {0} : {1}", sum,
                                (long)sw.ElapsedMilliseconds);
        }
    
        static void FindSumWithAsThenHasThenCast(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            foreach (object o in values)
            {
                int? x = o as int?;
    
                if (x.HasValue)
                {
                    sum += (int)o;
                }
            }
            sw.Stop();
            Console.WriteLine("As then Has then Cast: {0} : {1}", sum,
                                (long)sw.ElapsedMilliseconds);
        }
    
        static void FindSumWithManualAs(object[] values)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            foreach (object o in values)
            {
                bool hasValue = o is int;
                int x = hasValue ? (int)o : 0;
    
                if (hasValue)
                {
                    sum += x;
                }
            }
            sw.Stop();
            Console.WriteLine("Manual As: {0} : {1}", sum,
                                (long)sw.ElapsedMilliseconds);
        }
    
        static void FindSumWithAsThenManualHasThenValue(object[] values)
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
            Console.WriteLine("As then Manual Has then Value: {0} : {1}", sum,
                                (long)sw.ElapsedMilliseconds);
        }
    
    }
