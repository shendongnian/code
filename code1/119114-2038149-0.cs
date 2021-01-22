    string html;
    // obtain some arbitrary html....
    using (var client = new WebClient()) {
        html = client.DownloadString("http://stackoverflow.com/questions/2038104");
    }
    // use the html agility pack: http://www.codeplex.com/htmlagilitypack
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(html);
    StringBuilder sb = new StringBuilder();
    foreach (HtmlTextNode node in doc.DocumentNode.SelectNodes("//text()")) {
        sb.AppendLine(node.Text);
    }
    string final = sb.ToString();
