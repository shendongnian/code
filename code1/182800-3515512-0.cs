    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace SBTest
    {
      class Program
      {
        private static void Main(string[] args)
        {
          // JIT everything
          AppendTest(1);
          AppendFormatTest(1);
    
          int iterations = 1000000;
    
          // Run Tests
          TestRunner(AppendTest, iterations);
          TestRunner(AppendFormatTest, iterations);
    
          Console.ReadLine();
        }
    
        private static void TestRunner(Func<int, long> action, int iterations)
        {
          GC.Collect();
    
          var sw = Stopwatch.StartNew();
          long length = action(iterations);
          sw.Stop();
    
          Console.WriteLine("--------------------- {0} -----------------------", action.Method.Name);
          Console.WriteLine("iterations: {0:n0}", iterations);
          Console.WriteLine("milliseconds: {0:n0}", sw.ElapsedMilliseconds);
          Console.WriteLine("output length: {0:n0}", length);
          Console.WriteLine("");
        }
    
        private static long AppendTest(int iterations)
        {
          var sb = new StringBuilder();
    
          for (var i = 0; i < iterations; i++)
          {
            sb.Append("TEST" + i.ToString("00000"),
                      "TEST" + (i + 1).ToString("00000"),
                      "TEST" + (i + 2).ToString("00000"));
          }
    
          return sb.Length;
        }
    
        private static long AppendFormatTest(int iterations)
        {
          var sb = new StringBuilder();
    
          for (var i = 0; i < iterations; i++)
          {
            sb.AppendFormat("{0}{1}{2}",
                "TEST" + i.ToString("00000"),
                "TEST" + (i + 1).ToString("00000"),
                "TEST" + (i + 2).ToString("00000"));
          }
    
          return sb.Length;
        }
      }
    
      public static class SBExtentions
      {
        public static void Append(this StringBuilder sb, params string[] args)
        {
          foreach (var arg in args)
            sb.Append(arg);
        }
      }
    }
