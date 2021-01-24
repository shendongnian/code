    public static void setColor(string color)
    {
        try
        {
             Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
        }
        catch (Exception)
        {
            //catch error for an invalid color
        }
    }
