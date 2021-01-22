    var d = s.ToCharArray();
    Array.Reverse(d);
    return s == new string(d);
---
    using System;
    using System.Diagnostics;
    
    namespace longeststring_codegolf
    {
        class Program
        {
            static void Main(string[] args)
            {
                int t = 0, v = 0;
                var sw = new Stopwatch();
    
                sw.Start();
                for (int i = 999; i > 99; i--)
                    for (int j = 999; j > 99; j--)
                        if ((v = i * j) > t && IsPalindromicMine(v.ToString()))
                            t = v;
                sw.Stop();
    
                var elapsed = sw.Elapsed;
                var elapsedMilliseconds = sw.ElapsedMilliseconds;
                var elapsedTicks = sw.ElapsedTicks; 
                Console.WriteLine("Ticks: " + elapsedTicks.ToString());//~189000
                Console.WriteLine("Milliseconds: " + elapsedMilliseconds.ToString()); //~9
    
                sw = Stopwatch.StartNew();
                for (int i = 999; i > 99; i--)
                    for (int j = 999; j > 99; j--)
                        if ((v = i * j) > t && IsPalindromic(v.ToString()))
                            t = v;
                sw.Stop();
                var elapsed2 = sw.Elapsed;
                var elapsedMilliseconds2 = sw.ElapsedMilliseconds;
                var elapsedTicks2 = sw.ElapsedTicks; 
                Console.WriteLine("Ticks: " + elapsedTicks2.ToString());//~388000
                Console.WriteLine("Milliseconds: " + elapsedMilliseconds2.ToString());//~20
    
            }
    
            static bool IsPalindromicMine(string s)
            {
                var d = s.ToCharArray();
                Array.Reverse(d);
                return s == new string(d);
            }
    
            static bool IsPalindromic(string s)
            {
                int len = s.Length;
                int half = len-- >> 1;
                for (int i = 0; i < half; i++)
                    if (s[i] != s[len - i])
                        return false;
                return true;
            }
    
        }
    }
