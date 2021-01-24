        private static void Main()
        {
            var sorted = string.Empty;
            while (true)
            {
                var readChar = Console.ReadKey().KeyChar;
                sorted = String.Concat((sorted + readChar).OrderBy(c => c));
                Console.WriteLine($"{Environment.NewLine} - Sorted input: {sorted}");
            }
        }
