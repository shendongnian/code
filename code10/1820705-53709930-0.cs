    public static class ConsoleExtensions
    {
        public static void WriteToConsole(this IEnumerable<string> list)
        {
            foreach (string item in list)
                Console.WriteLine(item);
        }
    }
