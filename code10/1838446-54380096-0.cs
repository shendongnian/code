namespace ConsoleApp1
{
    public class Program
    {
        private static void Main(string[] args)
        {
//            OptionPlain();
            OptionRegex();
        }
        private static void OptionPlain()
        {
            var mapping = new Dictionary<char, string>()
            {
                { '.', "Dot" },
                { '0', "Number" },
                { '1', "Number" },
                { '2', "Number" },
                { '3', "Number" },
                { '4', "Number" },
                { '5', "Number" },
                { '6', "Number" },
                { '7', "Number" },
                { '8', "Number" },
                { '9', "Number" },
                { 'Q', "Letter" }
            };
            char key;
            Console.WriteLine("Press Q to Exit");
            do
            {
                key = Console.ReadKey().KeyChar.ToString().ToUpperInvariant()[0]; // Just doing this to not have to handle upper and lower chars
                if (!mapping.ContainsKey(key))
                {
                    Console.WriteLine($"I don't know what you are saying");
                    continue;
                }
                Console.WriteLine($"You typed a {mapping[key]}");
            } while (key != 'Q');
        }
        private static void OptionRegex()
        {
            var mappings = new Dictionary<string, string>()
            {
                { "^\\.$", "Dot" },
                { "^[0-9]$", "Number" },
                { "^[A-Z]$", "Letter" }
            };
            char key;
            Console.WriteLine("Press Q to Exit");
            do
            {
                key = Console.ReadKey().KeyChar.ToString().ToUpperInvariant()[0]; // Just doing this to not have to handle upper and lower chars
                var firstMatch = mappings
                    .Where(mapping => Regex.IsMatch(key.ToString(), mapping.Key))
                    .Select(mapping => mapping.Value)
                    .FirstOrDefault();
                if (firstMatch == null)
                {
                    Console.WriteLine($"I don't know what you are saying");
                    continue;
                }
                Console.WriteLine($"You typed a {firstMatch}");
            } while (key != 'Q');
        }
    }
}
