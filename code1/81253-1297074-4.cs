    using System;
    using System.Linq.Expressions;
    using System.Reflection.Emit;
    using System.Diagnostics;
    
    namespace Sandbox
    {
        public class Program
        {
            public static void Main(String[] args)
            {
                DynamicMethod method = new DynamicMethod("TestMethod",
                    typeof(Int32), new Type[] { typeof(object), typeof(Int32), typeof(Int32) });
                var il = method.GetILGenerator();
    
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Add);
                il.Emit(OpCodes.Ret);
                
                method.Invoke(null, new object[] { null, 0, 0 });
                Func<Int32, Int32, Int32> f1 =
                    (Func<Int32, Int32, Int32>)method.CreateDelegate(
                        typeof(Func<Int32, Int32, Int32>), null);
                Func<Int32, Int32, Int32> f2 = (Int32 a, Int32 b) => a + b;
                Func<Int32, Int32, Int32> f3 = Sum;
                Expression<Func<Int32, Int32, Int32>> f4x = (a, b) => a + b;
                Func<Int32, Int32, Int32> f4 = f4x.Compile();
                for (Int32 pass = 1; pass <= 2; pass++)
                {
                    // Pass 1 just runs all the code without writing out anything
                    // to avoid JIT overhead influencing the results
                    Time(f1, "DynamicMethod", pass);
                    Time(f2, "Lambda", pass);
                    Time(f3, "Method", pass);
                    Time(f4, "Expression", pass);
                }
            }
    
            private static void Time(Func<Int32, Int32, Int32> fn,
                String name, Int32 pass)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (Int32 index = 0; index <= 100000000; index++)
                {
                    Int32 result = fn(index, 1);
                }
                sw.Stop();
                if (pass == 2)
                    Console.WriteLine(name + ": " + sw.ElapsedMilliseconds + " ms");
            }
    
            private static Int32 Sum(Int32 a, Int32 b)
            {
                return a + b;
            }
        }
    }
