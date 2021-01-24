namespace ConsoleApp1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var done = false;
            Console.WriteLine("Press Q to Exit");
            while (!done)
            {
                var key = GrabUpperKey();
                var mapped1 = MapPlain(key);
                var mapped2 = MapRegexDynamic(key);
                var mapped3 = MapRegexConditional(key);
                Console.WriteLine($"You typed a {mapped1}, {mapped2}, {mapped3}");
                done = key == "Q";
            }
        }
        private static string MapRegexConditional(string key)
        {
            if (Regex.IsMatch(key, "^[0-9]$"))
            {
                return "Number";
            }
            if (Regex.IsMatch(key, @"^[\.]$"))
            {
                return "Dot";
            }
            if (Regex.IsMatch(key, @"^[A-Z]$"))
            {
                return "Letter";
            }
            return "N/A";
        }
        private static string MapRegexDynamic(string key)
        {
            var mappings = new Dictionary<string, string>()
            {
                { "^\\.$", "Dot" },
                { "^[0-9]$", "Number" },
                { "^[A-Z]$", "Letter" }
            };
            var firstMatch = mappings
                .Where(mapping => Regex.IsMatch(key.ToString(), mapping.Key))
                .Select(mapping => mapping.Value)
                .FirstOrDefault();
            return firstMatch ?? "N/A";
        }
        private static string MapPlain(string key)
        {
            var mapping = new Dictionary<string, string>()
            {
                { ".", "Dot" },
                { "0", "Number" },
                { "1", "Number" },
                { "2", "Number" },
                { "3", "Number" },
                { "4", "Number" },
                { "5", "Number" },
                { "6", "Number" },
                { "7", "Number" },
                { "8", "Number" },
                { "9", "Number" },
                { "A", "Letter" },
                { "Q", "Letter" }
            };
            return !mapping.ContainsKey(key) ? "N/A" : mapping[key];
        }
        private static string GrabUpperKey()
        {
            return Console.ReadKey().KeyChar.ToString().ToUpperInvariant(); // Just doing this to not have to handle upper and lower chars
        }
    }
}
