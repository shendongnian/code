    public void GetAllImages()
        {
            WebClient x = new WebClient();
            string source = x.DownloadString(@"http://www.google.com");
    
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            List<string> image_links = new List<string>();
            document.Load(source);
    
            foreach(HtmlNode link in document.DocumentElement.SelectNodes("//img"))
            {
              image_links.Add( link.GetAttributeValue("src", "") );
           }
    
    
        }
