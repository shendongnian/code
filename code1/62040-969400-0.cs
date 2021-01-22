    using System;
    using System.Text.RegularExpressions;
    using DotNetUtils.Diagnostics;
    class Program {
        static private readonly string[] TestData = new string[] {
            "10.0",
            "10,0",
            "0.1",
            ".1",
            "Snafu",
            new string('x', 10000),
            new string('2', 10000),
            new string('0', 10000)
        };
        static void Main(string[] args) {
            Action parser = () => {
                int n = TestData.Length;
                int count = 0;
                for (int i = 0; i < n; ++i) {
                    decimal dummy;
                    count += Decimal.TryParse(TestData[i], out dummy) ? 1 : 0;
                }
            };
            Regex decimalRegex = new Regex(@"^[0-9]([\.\,][0-9]{1,3})?$");
            Action regex = () => {
                int n = TestData.Length;
                int count = 0;
                for (int i = 0; i < n; ++i) {
                    count += decimalRegex.IsMatch(TestData[i]) ? 1 : 0;
                }
            };
            var paserTotal = 0.0;
            var regexTotal = 0.0;
            var runCount = 10;
            for (int run = 1; run <= runCount; ++run) {
                var parserTime = PerformanceHelper.Run(10000, parser);
                var regexTime = PerformanceHelper.Run(10000, regex);
                Console.WriteLine("Run #{2}: Decimal.TryParse: {0}ms, Regex: {1}ms",
                                  parserTime.TotalMilliseconds, 
                                  regexTime.TotalMilliseconds,
                                  run);
                paserTotal += parserTime.TotalMilliseconds;
                regexTotal += regexTime.TotalMilliseconds;
            }
            Console.WriteLine("Overall averages: Decimal.TryParse: {0}ms, Regex: {1}ms",
                              paserTotal/runCount,
                              regexTotal/runCount);
        }
    }
