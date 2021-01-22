    public static void DumpString(string text)
    {
        Console.WriteLine("Text: '{0}'", text);
        foreach (char c in text)
        {
            Console.WriteLine("{0}: U+{1:x4}", c, (int) c);
        }
    }
