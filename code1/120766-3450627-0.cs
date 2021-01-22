    using System;
    namespace CommonPrefix
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(CommonPrefix(new[] { "h:/a/b/c", "h:/a/b/d", "h:/a/b/e", "h:/a/c" })); // "h:/a/"
                Console.WriteLine(CommonPrefix(new[] { "abc", "abc" })); // "abc"
                Console.WriteLine(CommonPrefix(new[] { "abc" })); // "abc"
                Console.WriteLine(CommonPrefix(new string[] { })); // ""
                Console.WriteLine(CommonPrefix(new[] { "a", "abc" })); // "a"
                Console.WriteLine(CommonPrefix(new[] { "abc", "a" })); // "a"
    
                Console.ReadKey();
            }
    
            private static string CommonPrefix(string[] ss)
            {
                if (ss.Length == 0)
                {
                    return "";
                }
    
                if (ss.Length == 1)
                {
                    return ss[0];
                }
    
                int prefixLength = 0;
    
                foreach (char c in ss[0])
                {
                    foreach (string s in ss)
                    {
                        if (s.Length <= prefixLength || s[prefixLength] != c)
                        {
                            return ss[0].Substring(0, prefixLength);
                        }
                    }
                    prefixLength++;
                }
    
                return ss[0]; // all strings identical
            }
        }
    }
