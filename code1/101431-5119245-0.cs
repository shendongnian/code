    public static string ConsoleReadLineWithDefault(string defaultValue)
    {
        System.Windows.Forms.SendKeys.SendWait(defaultValue);
        return Console.ReadLine();
    }
