    class Program
    {
        static void Main(string[] args)
        {
            HtmlParserOptions opt1 = HtmlParserOptions.NotifyText | HtmlParserOptions.NotifyEmptyText;
            Console.WriteLine("Text: {0}", opt1.IsOptionSet(HtmlParserOptions.NotifyText));
            Console.WriteLine("OpeningTags: {0}", opt1.IsOptionSet(HtmlParserOptions.NotifyOpeningTags));
            Console.ReadKey();
        } 
    }
