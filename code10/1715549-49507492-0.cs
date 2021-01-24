    var doc = new HtmlAgilityPack.HtmlDocument
    {
       OptionFixNestedTags = true,
       OptionCheckSyntax = true,
       OptionAutoCloseOnEnd = true
    };
    doc.LoadHtml(html);
    List<List<HtmlAgilityPack.HtmlNode>> parsedTbl =
                  doc.DocumentNode.SelectSingleNode("//table[@class='MyClass']")
                  .Descendants("tr")
                  .Skip(1)
                  .Where(tr => tr.Elements("td").Count() > 1)
                  .Select(tr => tr.Elements("td").ToList())
                  .ToList();
    
    foreach (var r in parsedTbl)
    {
       Console.WriteLine(r[0].FirstChild.Attributes["href"].Value + "  " + r[0].InnerText + "  " + r[1].InnerText); //HOW TO INCLUDE HREF INFO?
    }
