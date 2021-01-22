    private static void Main()
    {
        ConsoleColor c;
        if (ColorHelpers.TryGetConsoleColor(Color.Red, out c))
        {
            Console.ForegroundColor = c;
        }
    }
