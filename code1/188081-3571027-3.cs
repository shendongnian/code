    class Program
    {
        static void Main(string[] args)
        {
            var scraper = new YouTubeScraper();
            HtmlNode davidAfterDentistEmbedNode = scraper.FindEmbedElement("http://www.youtube.com/watch?v=txqiwrbYGrs");
            Console.WriteLine("David After Dentist:");
            Console.WriteLine(davidAfterDentistEmbedNode.OuterHtml);
            Console.WriteLine();
            HtmlNode drunkHistoryObjectNode = scraper.FindObjectElement("http://www.youtube.com/watch?v=jL68NyCSi8o");
            Console.WriteLine("Drunk History:");
            Console.WriteLine(drunkHistoryObjectNode.OuterHtml);
            Console.WriteLine();
            HtmlNode jessicaDailyAffirmationEmbedNode = scraper.FindEmbedElement("http://www.youtube.com/watch?v=qR3rK0kZFkg");
            Console.WriteLine("Jessica's Daily Affirmation:");
            Console.WriteLine(jessicaDailyAffirmationEmbedNode.OuterHtml);
            Console.WriteLine();
            HtmlNode jazzerciseObjectNode = scraper.FindObjectElement("http://www.youtube.com/watch?v=VGOO8ZhWFR4");
            Console.WriteLine("Jazzercise - Move your Boogie Body:");
            Console.WriteLine(jazzerciseObjectNode.OuterHtml);
            Console.WriteLine();
            Console.Write("Finished! Hit Enter to quit.");
            Console.ReadLine();
        }
    }
