    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    namespace Test
    {
        static class Program
        {
            static void Main()
            {
                // Set number of prefixes and calls to not more than 50 to get results
                // printed to the console.
    
                Console.Write("Generating prefixes");
                List<String> prefixes = Program.GeneratePrefixes(5, 10, 15);
                Console.WriteLine();
    
                Console.Write("Generating calls");
                List<Call> calls = Program.GenerateCalls(prefixes, 5, 10, 50);
                Console.WriteLine();
    
                Console.WriteLine("Processing started.");
    
                Stopwatch stopwatch = new Stopwatch();
    
                const Int32 prefixminlength = 5;
    
                stopwatch.Start();
    
                var groupedPefixes = prefixes
                    .GroupBy(p => p.Substring(0, prefixminlength))
                    .ToDictionary(g => g.Key, g => g);
    
                var result = calls
                    .GroupBy(c => groupedPefixes[c.Number.Substring(0, prefixminlength)]
                        .First(c.Number.StartsWith))
                    .Select(g => new Call(g.Key, g.Sum(i => i.Duration)))
                    .ToList();
    
                stopwatch.Stop();
    
                Console.WriteLine("Processing finished.");
                Console.WriteLine(stopwatch.Elapsed);
    
                if ((prefixes.Count <= 50) && (calls.Count <= 50))
                {
                    Console.WriteLine("Prefixes");
                    foreach (String prefix in prefixes)
                    {
                        Console.WriteLine(String.Format("  prefix={0}", prefix));
                    }
    
                    Console.WriteLine("Calls");
                    foreach (Call call in calls)
                    {
                        Console.WriteLine(String.Format("  number={0} duration={1}", call.Number, call.Duration));
                    }
    
                    Console.WriteLine("Result");
                    foreach (Call call in result)
                    {
                        Console.WriteLine(String.Format("  prefix={0} accumulated duration={1}", call.Number, call.Duration));
                    }
                }
                
                Console.ReadLine();
            }
    
            private static List<String> GeneratePrefixes(Int32 minimumLength, Int32 maximumLength, Int32 count)
            {
                Random random = new Random();
                List<String> prefixes = new List<String>(count);
                StringBuilder stringBuilder = new StringBuilder(maximumLength);
    
                while (prefixes.Count < count)
                {
                    stringBuilder.Length = 0;
    
                    for (int i = 0; i < random.Next(minimumLength, maximumLength + 1); i++)
                    {
                        stringBuilder.Append(random.Next(10));
                    }
    
                    String prefix = stringBuilder.ToString();
    
                    if (prefixes.Count % 1000 == 0)
                    {
                        Console.Write(".");
                    }
    
                    if (prefixes.All(p => !p.StartsWith(prefix) && !prefix.StartsWith(p)))
                    {
                        prefixes.Add(stringBuilder.ToString());
                    }
                }
    
                return prefixes;
            }
    
            private static List<Call> GenerateCalls(List<String> prefixes, Int32 minimumLength, Int32 maximumLength, Int32 count)
            {
                Random random = new Random();
                List<Call> calls = new List<Call>(count);
                StringBuilder stringBuilder = new StringBuilder();
    
                while (calls.Count < count)
                {
                    stringBuilder.Length = 0;
    
                    stringBuilder.Append(prefixes[random.Next(prefixes.Count)]);
    
                    for (int i = 0; i < random.Next(minimumLength, maximumLength + 1); i++)
                    {
                        stringBuilder.Append(random.Next(10));
                    }
    
                    if (calls.Count % 1000 == 0)
                    {
                        Console.Write(".");
                    }
    
                    calls.Add(new Call(stringBuilder.ToString(), random.Next(1000)));
                }
    
                return calls;
            }
    
            private class Call
            {
                public Call (String number, Decimal duration)
                {
                    this.Number = number;
                    this.Duration = duration;
                }
    
                public String Number { get; private set; }
                public Decimal Duration { get; private set; }
            }
        }
    }
