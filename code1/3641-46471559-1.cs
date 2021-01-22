    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace memcmp
    {
        class Program
        {
            static byte[] TestVector(int size)
            {
                var data = new byte[size];
                using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    rng.GetBytes(data);
                }
                return data;
            }
    
            static TimeSpan Measure(string testCase, TimeSpan offset, Action action, bool ignore = false)
            {
                var t = Stopwatch.StartNew();
                var n = 0L;
                while (t.Elapsed < TimeSpan.FromSeconds(10))
                {
                    action();
                    n++;
                }
                var elapsed = t.Elapsed - offset;
                if (!ignore)
                {
                    Console.WriteLine($"{testCase,-16} : {n / elapsed.TotalSeconds,16:0.0} MiB/s");
                }
                return elapsed;
            }
    
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern int memcmp(byte[] b1, byte[] b2, long count);
    
            static void Main(string[] args)
            {
                // how quickly can we establish if two sequences of bytes are equal?
    
                // note that we are testing the speed of different comparsion methods
    
                var a = TestVector(1024 * 1024); // 1 MiB
                var b = (byte[])a.Clone();
    
                var offset = Measure("offset", new TimeSpan(), () => { return; }, ignore: true);
    
                Measure("StructuralComparison", offset, () =>
                {
                    StructuralComparisons.StructuralEqualityComparer.Equals(a, b);
                });
    
                Measure("for", offset, () =>
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] != b[i]) break;
                    }
                });
    
                Measure("ToUInt32", offset, () =>
                {
                    for (int i = 0; i < a.Length; i += 4)
                    {
                        if (BitConverter.ToUInt32(a, i) != BitConverter.ToUInt32(b, i)) break;
                    }
                });
    
                Measure("ToUInt64", offset, () =>
                {
                    for (int i = 0; i < a.Length; i += 8)
                    {
                        if (BitConverter.ToUInt64(a, i) != BitConverter.ToUInt64(b, i)) break;
                    }
                });
    
                Measure("memcmp", offset, () =>
                {
                    memcmp(a, b, a.Length);
                });
            }
        }
    }
