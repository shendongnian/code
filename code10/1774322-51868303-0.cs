    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    namespace MyBenchmarks
    {
    #if NETCOREAPP2_1
        [CoreJob]
    #else
        [ClrJob]
    #endif
        [RankColumn, MarkdownExporterAttribute.StackOverflow]
        public class Benchmark
        {
            static readonly string[] words = new[]
            {
                "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"
            };
            // borrowed from greg (https://stackoverflow.com/questions/4286487/is-there-any-lorem-ipsum-generator-in-c)
            static IEnumerable<string> LoremIpsum(Random random, int minWords, int maxWords, int minSentences, int maxSentences, int numLines)
            {
                var line = new StringBuilder();
                for (int l = 0; l < numLines; l++)
                {
                    line.Clear();
                    var numSentences = random.Next(maxSentences - minSentences) + minSentences + 1;
                    for (int s = 0; s < numSentences; s++)
                    {
                        var numWords = random.Next(maxWords - minWords) + minWords + 1;
                        line.Append(words[random.Next(words.Length)]);
                        for (int w = 1; w < numWords; w++)
                        {
                            line.Append(" ");
                            line.Append(words[random.Next(words.Length)]);
                        }
                        line.Append(". ");
                    }
                    yield return line.ToString();
                }
            }
            string[] lines;
            [Params(1000, 1_000_000)]
            public int N;
            [Params("lorem", "lorem ipsum dolor sit amet consectetuer")]
            public string SearchValue;
            [GlobalSetup]
            public void GlobalSetup()
            {
                lines = LoremIpsum(new Random(), 6, 8, 2, 3, 1_000_000).ToArray();
            }
            public static int CountOccurrencesSub(string val, string searchFor)
            {
                if (string.IsNullOrEmpty(val) || string.IsNullOrEmpty(searchFor))
                { return 0; }
                int count = 0;
                for (int x = 0; x <= val.Length - searchFor.Length; x++)
                {
                    if (val.Substring(x, searchFor.Length) == searchFor)
                    { count++; }
                }
                return count;
            }
            public static int CountOccurrences(string val, string searchFor)
            {
                if (string.IsNullOrEmpty(val) || string.IsNullOrEmpty(searchFor))
                { return 0; }
                int count = 0;
                ReadOnlySpan<char> vSpan = val.AsSpan();
                ReadOnlySpan<char> searchSpan = searchFor.AsSpan();
                for (int x = 0; x <= vSpan.Length - searchSpan.Length; x++)
                {
                    if (vSpan.Slice(x, searchSpan.Length).SequenceEqual(searchSpan))
                    { count++; }
                }
                return count;
            }
            public static int CountOccurrencesCmp(string val, string searchFor)
            {
                if (string.IsNullOrEmpty(val) || string.IsNullOrEmpty(searchFor))
                { return 0; }
                int count = 0;
                for (int x = 0; x <= val.Length - searchFor.Length; x++)
                {
                    if (string.CompareOrdinal(val, x, searchFor, 0, searchFor.Length) == 0)
                    { count++; }
                }
                return count;
            }
            [Benchmark(Baseline = true)]
            public int Substring()
            {
                int occurences = 0;
                for (var i = 0; i < N; i++)
                    occurences += CountOccurrencesSub(lines[i], SearchValue);
                return occurences;
            }
            [Benchmark]
            public int Span()
            {
                int occurences = 0;
                for (var i = 0; i < N; i++)
                    occurences += CountOccurrences(lines[i], SearchValue);
                return occurences;
            }
            [Benchmark]
            public int Compare()
            {
                int occurences = 0;
                for (var i = 0; i < N; i++)
                    occurences += CountOccurrencesCmp(lines[i], SearchValue);
                return occurences;
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                BenchmarkRunner.Run<Benchmark>();
            }
        }
    }
