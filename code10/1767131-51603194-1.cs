    using System;
    using System.Globalization;
    using BenchmarkDotNet.Attributes;
    namespace StackOverflow_51584129
    {
        public class FloatParsingBenchmarks
        {
            private const string InputString = "132.29";
            private static readonly byte[] InputBytes = System.Text.Encoding.ASCII.GetBytes(InputString);
            private static readonly IFormatProvider ParsingFormatProvider = CultureInfo.InvariantCulture;
            private const NumberStyles LaxParsingNumberStyles = NumberStyles.Float;
            private const NumberStyles StrictParsingNumberStyles = NumberStyles.AllowDecimalPoint;
            private const char DecimalSeparator = '.';
            [Benchmark(Baseline = true, Description = "float.Parse(string)")]
            public float SystemFloatParse()
            {
                return float.Parse(InputString);
            }
            [Benchmark(Description = "float.Parse(string, IFormatProvider)")]
            public float SystemFloatParseWithProvider()
            {
                return float.Parse(InputString, CultureInfo.InvariantCulture);
            }
            [Benchmark(Description = "float.Parse(string, NumberStyles) [Lax]")]
            public float SystemFloatParseWithLaxNumberStyles()
            {
                return float.Parse(InputString, LaxParsingNumberStyles);
            }
            [Benchmark(Description = "float.Parse(string, NumberStyles) [Strict]")]
            public float SystemFloatParseWithStrictNumberStyles()
            {
                return float.Parse(InputString, StrictParsingNumberStyles);
            }
            [Benchmark(Description = "float.Parse(string, NumberStyles, IFormatProvider) [Lax]")]
            public float SystemFloatParseWithLaxNumberStylesAndProvider()
            {
                return float.Parse(InputString, LaxParsingNumberStyles, ParsingFormatProvider);
            }
            [Benchmark(Description = "float.Parse(string, NumberStyles, IFormatProvider) [Strict]")]
            public float SystemFloatParseWithStrictNumberStylesAndProvider()
            {
                return float.Parse(InputString, StrictParsingNumberStyles, ParsingFormatProvider);
            }
            [Benchmark(Description = "Custom byte-to-float parser [Indexer]")]
            public float CustomFloatParseByIndexing()
            {
                // FOR DEMONSTRATION PURPOSES ONLY!
                // This code has been written for and only tested with
                // parsing the ASCII string "132.29" in byte form
                var currentIndex = 0;
                var boundaryIndex = InputBytes.Length;
                char currentChar;
                var wholePart = 0;
                while (currentIndex < boundaryIndex && (currentChar = (char) InputBytes[currentIndex++]) != DecimalSeparator)
                {
                    var currentDigit = currentChar - '0';
                    wholePart = 10 * wholePart + currentDigit;
                }
                var fractionalPart = 0F;
                var nextFractionalDigitScale = 0.1F;
                while (currentIndex < boundaryIndex)
                {
                    currentChar = (char) InputBytes[currentIndex++];
                    var currentDigit = currentChar - '0';
                    fractionalPart += currentDigit * nextFractionalDigitScale;
                    nextFractionalDigitScale *= 0.1F;
                }
                return wholePart + fractionalPart;
            }
            [Benchmark(Description = "Custom byte-to-float parser [Enumerator]")]
            public float CustomFloatParseByEnumerating()
            {
                // FOR DEMONSTRATION PURPOSES ONLY!
                // This code has been written for and only tested with
                // parsing the ASCII string "132.29" in byte form
                var wholePart = 0;
                var enumerator = InputBytes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var currentChar = (char) (byte) enumerator.Current;
                    if (currentChar == DecimalSeparator)
                        break;
                    var currentDigit = currentChar - '0';
                    wholePart = 10 * wholePart + currentDigit;
                }
                var fractionalPart = 0F;
                var nextFractionalDigitScale = 0.1F;
                while (enumerator.MoveNext())
                {
                    var currentChar = (char) (byte) enumerator.Current;
                    var currentDigit = currentChar - '0';
                    fractionalPart += currentDigit * nextFractionalDigitScale;
                    nextFractionalDigitScale *= 0.1F;
                }
                return wholePart + fractionalPart;
            }
            public static void Main()
            {
                BenchmarkDotNet.Running.BenchmarkRunner.Run<FloatParsingBenchmarks>();
            }
        }
    }
