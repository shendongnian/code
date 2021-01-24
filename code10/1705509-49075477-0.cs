        public static void Main(string[] args)
        {
            Console.WriteLine("Program Started!");
            HtmlDocument doc;
            doc = new HtmlWeb().Load("https://rotogrinders.com/grids/nba-defense-vs-position-cheat-sheet-1493632?site=fanduele");
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//section[@class='bdy content article full cflex reset long table-page']/following-sibling::script[1]");
            int start = node.InnerText.IndexOf("[");
            int length = node.InnerText.IndexOf("]") - start +1;
            Console.WriteLine(node.InnerText.Substring(start, length));
            Console.WriteLine("Program Ended!");
            Console.ReadKey();
        }
