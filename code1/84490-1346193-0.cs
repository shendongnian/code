    StringBuilder sb = new StringBuilder();
    foreach (HtmlAgilityPack.HtmlTextNode node in
          doc.DocumentNode.SelectNodes("//div/text()"))
    {
        sb.Append(node.Text.Trim());
    }
    string s = sb.ToString();
