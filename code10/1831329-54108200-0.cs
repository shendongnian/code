    private static void ChangeBackGroundColor(string ColorName)
    {
        if (Enum.TryParse(ColorName, out ConsoleColor Color))
            Console.BackgroundColor = Color;
        Console.Clear();
    }
