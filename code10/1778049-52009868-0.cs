    private static void Main()
    {
        string name = "&lt;div class=\"ExternalClassA6E\"&gt;&lt;p&gt;​&lt;span&gt;" + 
            "GET6&lt;/span&gt;&lt;/p&gt;&lt;/div&gt;";
        Console.WriteLine(name);
        Console.WriteLine(HttpUtility.HtmlDecode(name));
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
