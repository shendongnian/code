    namespace ConsoleTestApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var before = "4122,6384,0,\"20,000 BONUS POINTS\",,TRUE";
                var pattern = @"""[^""]*""";
                var after = Regex.Replace(before, pattern, match => match.Value.Replace(",", ""));
                Console.WriteLine(after);
            }
        }
    }
