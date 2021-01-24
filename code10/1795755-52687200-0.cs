     HtmlDocument doc = new HtmlDocument();
     string htmlContent = "<input id=\"item_Job_ID\" name=\"item.Job_ID\" type=\"text\" value=\"5036\">";
     doc.LoadHtml(htmlContent);
     HtmlNode inputNode = doc.DocumentNode.FirstChild;
     string value = inputNode.GetAttributeValue("value", "0");
