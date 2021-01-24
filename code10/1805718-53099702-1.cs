    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = Console.ReadLine();
                var sw = new System.Diagnostics.Stopwatch();
    
                sw.Start();
                for (int i = 0; i < 100000; i++)
                {
                    RunDistinct(input);
                }
                sw.Stop();
                Console.WriteLine($"Distinct {sw.ElapsedMilliseconds}");
    
                sw.Reset();
                sw.Start();
                for (int i = 0; i < 100000; i++)
                {
                    RunForEach1(input);
                }
                sw.Stop();
                Console.WriteLine($"RunForEach1 {sw.ElapsedMilliseconds}");
    
                sw.Reset();
                sw.Start();
                for (int i = 0; i < 100000; i++)
                {
                    RunForEach2(input);
                }
                sw.Stop();
                Console.WriteLine($"RunForEach2 {sw.ElapsedMilliseconds}");
    
                sw.Reset();
                sw.Start();
                for (int i = 0; i < 100000; i++)
                {
                    RunFor(input);
                }
                sw.Stop();
                Console.WriteLine($"RunFor {sw.ElapsedMilliseconds}");
    
                Console.ReadKey();
            }
    
    
            private static string RunDistinct(string input) {
                return new string(input.Distinct().ToArray());
            }
    
            private static string RunForEach1(string input) {
                var charOccurences = new Dictionary<char, int>();
                int removeEvery = 2;
                var outputBuilder = new StringBuilder();
    
                foreach (char c in input)
                {
                    charOccurences.TryGetValue(c, out int charOccurence);
                    charOccurence++;
                    charOccurences[c] = charOccurence;
                    if (charOccurence % removeEvery != 0)
                        outputBuilder.Append(c);
                }
    
                return outputBuilder.ToString();
            }
    
            private static string RunForEach2(string input)
            {
                var oddOccurrences = new HashSet<char>();
                var output = new StringBuilder();
                foreach (var c in input)
                {
                    if (!oddOccurrences.Contains(c))
                    {
                        output.Append(c);
                        oddOccurrences.Add(c);
                    }
                    else
                    {
                        oddOccurrences.Remove(c);
                    }
                }
                return output.ToString();
            }
    
            private static string RunFor(string input)
            {
                bool[] even = new bool[256];
                string output = "";
                for (int i = 0; i < input.Length; i++)
                {
                    int x = (int)input[i];
                    if (!even[x]) output += input[i];
                    even[x] = !even[x];
                }
    
                return output;
            }
        }
    }
