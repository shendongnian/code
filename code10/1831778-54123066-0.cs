    public void ColoredConsoleWrite(ConsoleColor firstColor, string firstText, ConsoleColor secondColor, string secondText)
    {
        Console.ForegroundColor = firstColor;
        Console.Write(firstText);
        Console.ForegroundColor = secondColor;
        Console.WriteLine(secondText);
    }
