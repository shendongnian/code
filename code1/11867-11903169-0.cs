    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    namespace ContainsAnyProgram
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string iphoneAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 5_0 like...";
                var majorAgents = new[] { "iPhone", "Android", "iPad" };
                var minorAgents = new[] { "Blackberry", "Windows Phone" };
                // true
                Console.WriteLine(iphoneAgent.ContainsAny(majorAgents));
                // false
                Console.WriteLine(iphoneAgent.ContainsAny(minorAgents));
                Console.ReadKey();
            }
        }
        public static class StringExtensions
        {
            /// <summary>
            /// Replicates Contains but for an array
            /// </summary>
            /// <param name="str">The string.</param>
            /// <param name="values">The values.</param>
            /// <returns></returns>
            public static bool ContainsAny(this string str, params string[] values)
            {
                if (!string.IsNullOrEmpty(str) && values.Length > 0)
                    return values.Any(str.Contains);
                return false;
            }
        }
    }
