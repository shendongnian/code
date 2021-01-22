    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReplaceAtChars: " + new Stopwatch().Time(() => "test".ReplaceAtChars(1, 'E').ReplaceAtChars(3, 'T'), 1000000) + "ms");
            Console.WriteLine("ReplaceAtSubstring: " + new Stopwatch().Time(() => "test".ReplaceAtSubstring(1, 'E').ReplaceAtSubstring(3, 'T'), 1000000) + "ms");
            Console.WriteLine("ReplaceAtStringBuilder: " + new Stopwatch().Time(() => "test".ReplaceAtStringBuilder(1, 'E').ReplaceAtStringBuilder(3, 'T'), 1000000) + "ms");
        }
    }
    public static class ReplaceAtExtensions
    {
        public static string ReplaceAtChars(this string source, int index, char replacement)
        {
            var temp = source.ToCharArray();
            temp[index] = replacement;
            return new String(temp);
        }
        public static string ReplaceAtStringBuilder(this string source, int index, char replacement)
        {
            var sb = new StringBuilder(source);
            sb[index] = replacement;
            return sb.ToString();
        }
        public static string ReplaceAtSubstring(this string source, int index, char replacement)
        {
            return source.Substring(0, index) + replacement + source.Substring(index + 1);
        }
    }
    public static class StopwatchExtensions
    {
        public static long Time(this Stopwatch sw, Action action, int iterations)
        {
            sw.Reset();
            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
