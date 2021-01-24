    class Program
    {
        static void Main(string[] args)
        {
            string htmlContent = File.ReadAllText(@"Your path to html file"); ;
    
            HtmlDocument doc = new HtmlDocument();
    
            doc.LoadHtml(htmlContent);
    
            var innerContent = doc.DocumentNode.SelectNodes("/div").FirstOrDefault().InnerHtml;
    
            Console.WriteLine(innerContent);
        }
    }
