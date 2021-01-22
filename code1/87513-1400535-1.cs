    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    namespace KMPSearch
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("Usage: " + Environment.GetCommandLineArgs()[0] + " haystack needle");
                }
                else
                {
                    KMPSearch search = new KMPSearch(args[0], args[1]);
                    int[] matches = search.MatchAll();
                    foreach (int i in matches)
                        Console.WriteLine("Match found at position " + i+1);
                }
            }
           
        }
    }
