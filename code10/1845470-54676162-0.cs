            var htmlCanada = webBrowserCanada.DocumentText;
            //Allows parsing the information out
            var htmlDocumentCanada = new HtmlAgilityPack.HtmlDocument();
            htmlDocumentCanada.LoadHtml(htmlCanada);
            //Parse the information
            var ProductsHtml = htmlDocumentCanada.DocumentNode
               .SelectSingleNode("//table[@id='tableid']")
                .Descendants("tr")
                .Skip(1)
                .Where(tr => tr.Elements("td").Count() > 1)
                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                .ToList();
