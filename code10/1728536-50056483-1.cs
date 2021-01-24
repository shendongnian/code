    public static void Main()
    {
            string pattern = @"\\.|\.+|\w+|[^\w\s]";
            string input = @"hello world.";
    
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.ECMAScript | RegexOptions.Singleline))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
    }
