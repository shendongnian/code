    class Program
    {
        static void Main()
        {
            Regex CSharpShortRegex =
                new Regex(@"""(?<constant>(\\.|[^""])*)""\.Localize\(\)");
            foreach (string line in File.ReadAllLines("input.txt"))
                foreach (Match match in CSharpShortRegex.Matches(line))
                    Console.WriteLine(match.Groups["constant"].Value);
        }
    }
