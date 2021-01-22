        static void Main(string[] args)
        {         
            var image = GrabImage("<h2>How to learn Photoshop</h2><p> Its <a href=\"/mysite.aspx\">link</a></p><br /> <img src=\"image.jpg\" alt=\"image\"/>");
            Console.WriteLine(image);
            Console.ReadLine();
        }
        private static string GrabImage(string htmlContent)
        {
            String firstImage;
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);
            HtmlAgilityPack.HtmlNode imageNode = htmlDoc.DocumentNode.SelectSingleNode("//img");
            if (imageNode != null)
            {
                firstImage = imageNode.OuterHtml.ToString();
            }
            else
                firstImage = " ";
            return firstImage;
        }
