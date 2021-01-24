    var client = new WebClient();
    string html = client.DownloadString(url);
    int lastTableOpen = html.LastIndexOf("<table");
    int lastTableClose = html.LastIndexOf("</table");
    string lastTable = html.Substring(lastTableOpen, lastTableClose - lastTableOpen + 8);
    var table = new HtmlDocument();
    table.LoadHtml(html);
    foreach (var row in table.DocumentNode.SelectNodes("//table/tr"))
    {
        Console.WriteLine(row.ToString());
    }
