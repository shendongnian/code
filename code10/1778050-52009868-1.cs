    private static void Main()
    {
        string copiedText = "&gt;​&lt;";
        string typedText = "&gt;&lt;";
        Console.WriteLine("\nCopied Text Results\n" + "-------------------");
        Console.WriteLine("\nLength: " + copiedText.Length);
        Console.WriteLine("\nCharacters and ascii values:");
        Console.WriteLine(string.Join(", ",
            copiedText.Select(character => character + " = " + (int) character)));
        Console.WriteLine("\nString value:");
        Console.WriteLine(copiedText);
        Console.WriteLine("\nHtml Decoded value:");
        Console.WriteLine(HttpUtility.HtmlDecode(copiedText));
        Console.WriteLine(Environment.NewLine + new string('-', Console.WindowWidth));
        Console.WriteLine("\nTyped Text Results\n" + "------------------");
        Console.WriteLine("\nLength: " + typedText.Length);
        Console.WriteLine("\nCharacters and ascii values:");
        Console.WriteLine(string.Join(", ",
            typedText.Select(character => character + " = " + (int) character)));
        Console.WriteLine("\nString value:");
        Console.WriteLine(typedText);
        Console.WriteLine("\nHtml Decoded value:");
        Console.WriteLine(HttpUtility.HtmlDecode(typedText));
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
