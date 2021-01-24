    public static void  WriteSign(string signText, int signWidth = 10, bool expandWidth = true)
    {
        // Split input into lines, in case there's 
        // more than one line to display on the sign
        var lines = signText
            .Split(new[] {'\r', '\n'}, StringSplitOptions.None)
            .Select(line => line.Trim());
        // Determine the sign width based on the longest line
        var actualSignWidth = expandWidth 
            ? Math.Max(lines.Max(l => l.Length), signWidth) 
            : signWidth;
        // Write header
        Console.WriteLine("╔" + new string('═', Math.Max(0, actualSignWidth)) + "╗");
        // Write lines
        foreach (var line in lines)
        {
            var signLine = line.Substring(0, Math.Min(line.Length, actualSignWidth))
            .PadLeft(Math.Min(actualSignWidth, (actualSignWidth + line.Length) / 2))
            .PadRight(actualSignWidth);
            Console.WriteLine("║" + signLine + "║");
        }
        // Write footer
        Console.WriteLine("╚" + new string('═', Math.Max(0, actualSignWidth)) + "╝");
    }
