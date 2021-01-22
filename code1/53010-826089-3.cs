    using System;
    using System.Linq;
    using System.Diagnostics;
    namespace StackOverflow826081
    {
        class Program
        {
            private const Int32 ITERATIONS = 1000000;
            static void Main()
            {
                String a;
                String[] ops = CreateArray();
                Int32 count;
                Stopwatch sw = new Stopwatch();
                Int32 pass = 0;
                Action<String, Int32> report = delegate(String title, Int32 i)
                {
                    if (pass == 2)
                        Console.Out.WriteLine(title + ": " + sw.ElapsedMilliseconds + " ms");
                };
    
                for (pass = 1; pass <= 2; pass++)
                {
                    #region || operator
    
                    a = "a";
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        if (a == "b" || a == "c")
                        {
                            count++;
                        }
                    }
                    sw.Stop();
                    report("||, not found", count);
                    sw.Reset();
    
                    a = "b";
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        if (a == "b" || a == "c")
                        {
                            count++;
                        }
                    }
                    sw.Stop();
                    report("||, found", count);
                    sw.Reset();
    
                    #endregion
    
                    #region array.Contains
    
                    a = "a";
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        if (ops.Contains(a))
                        {
                            count++;
                        }
                    }
                    sw.Stop();
                    report("array.Contains, not found", count);
                    sw.Reset();
    
                    a = "b";
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        if (ops.Contains(a))
                        {
                            count++;
                        }
                    }
                    sw.Stop();
                    report("array.Contains, found", count);
                    sw.Reset();
    
                    #endregion           
    
                    #region array.Contains
    
                    a = "a";
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        if (CreateArray().Contains(a))
                        {
                            count++;
                        }
                    }
                    sw.Stop();
                    report("array.Contains, inline array, not found", count);
                    sw.Reset();
    
                    a = "b";
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        if (CreateArray().Contains(a))
                        {
                            count++;
                        }
                    }
                    sw.Stop();
                    report("array.Contains, inline array, found", count);
                    sw.Reset();
    
                    #endregion
    
                    #region switch-statement
    
                    a = GetString().Substring(0, 1); // avoid interned string
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        switch (a)
                        {
                            case "b":
                            case "c":
                                count++;
                                break;
                        }
                    }
                    sw.Stop();
                    report("switch-statement, not interned, not found", count);
                    sw.Reset();
    
                    a = GetString().Substring(1, 1); // avoid interned string
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        switch (a)
                        {
                            case "b":
                            case "c":
                                count++;
                                break;
                        }
                    }
                    sw.Stop();
                    report("switch-statement, not interned, found", count);
                    sw.Reset();
    
                    #endregion                      
    
                    #region switch-statement
    
                    a = "a";
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        switch (a)
                        {
                            case "b":
                            case "c":
                                count++;
                                break;
                        }
                    }
                    sw.Stop();
                    report("switch-statement, interned, not found", count);
                    sw.Reset();
    
                    a = "b";
                    sw.Start();
    
                    count = 0;
                    for (Int32 index = 0; index < ITERATIONS; index++)
                    {
                        switch (a)
                        {
                            case "b":
                            case "c":
                                count++;
                                break;
                        }
                    }
                    sw.Stop();
                    report("switch-statement, interned, found", count);
                    sw.Reset();
    
                    #endregion
                }
            }
    
            private static String GetString()
            {
                return "ab";
            }
    
            private static String[] CreateArray()
            {
                return new String[] { "b", "c" };
            }
        }
    }
