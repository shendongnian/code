    var doc = new HtmlDocument();
    doc.LoadHtml("...your sample html...");
    // all <td> tags in the document
    foreach (HtmlNode td in doc.DocumentNode.SelectNodes("//td")) {
        Console.WriteLine(td.InnerText);
    }
    // all <span> tags in the document
    foreach (HtmlNode span in doc.DocumentNode.SelectNodes("//span")) {
        Console.WriteLine(span.InnerText);
    }
    // all <a> tags in the document
    foreach (HtmlNode a in doc.DocumentNode.SelectNodes("//a")) {
        Console.WriteLine(a.InnerText);
    }
