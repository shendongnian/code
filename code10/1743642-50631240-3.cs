    class Program
        {
            static void Main(string[] args)
            {
                var html = File.ReadAllText(@"d:/my.html");
    
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
    
                HtmlNodeCollection sections = htmlDoc.DocumentNode.SelectNodes("//*[@class='image-section']");
                var section = sections.FirstOrDefault();
                if (section != null)
                {
                    foreach (var imgElement in section.Elements("img"))
                    {
                        Console.WriteLine(imgElement.OuterHtml);
                    }
                }
    
                Console.ReadKey();
            }
        }
