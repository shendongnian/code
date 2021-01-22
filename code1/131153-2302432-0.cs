      WebClient client = new WebClient();
      string source = client.DownloadString(url);
                
      HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
      document.LoadHtml(source);
                
      HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//*[@href]");
                
       foreach (HtmlNode node in nodes)
       {
        if (node.Attributes.Contains("class"))
        {
         if (node.Attributes["class"].Value.Contains("StockData"))
         {// Here is our info }
        }
       }
