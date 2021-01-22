    public static string ReadWithDefaults(string defaultValue)
    {
        string str = Console.ReadLine();
        return String.IsNullOrEmpty(str) ? defaultValue : str;
    }
