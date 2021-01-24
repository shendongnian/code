    var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(File.ReadAllText("Input.html"));
    
                var element = htmlDoc.DocumentNode.Descendants()
                    .Where(x => x.InnerText == "To verify your identity, please use the following code:")
                    .ToList()
                    .FirstOrDefault();
                while (element.NextSibling.Name != "p")
                    element = element.NextSibling;
    
                var code= element.NextSibling.InnerText;
