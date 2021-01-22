    class Program
    {
        static void Main(string[] args)
        {
            var web = new HtmlWeb();
            var doc = web.Load("http://www.stackoverflow.com");
    
            var nodes = doc.DocumentNode.SelectNodes("//img[@src]");
    
            foreach (var node in nodes)
            {
                    Console.WriteLine(node.src);
            }
        }
    }
