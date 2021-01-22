    static void Main(string[] args)
    {
        string s = "223232-1.jpg";
        Console.WriteLine(FixText(s));
        s = "443-2.jpg";
        Console.WriteLine(FixText(s));
        s = "34443553-5.jpg";
        Console.WriteLine(FixText(s));
    
        Console.ReadKey();
    }
    
    private static string FixText(string text)
    {
        if (!String.IsNullOrWhiteSpace(text))
        {
            int charLocation = text.IndexOf("-");
    
            if (charLocation > 0)
            {
                return text.Substring(0, charLocation);
            }
        }
    
        return String.Empty;
    }
