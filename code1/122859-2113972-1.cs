    public void GetAllImages()
        {
            WebClient x = new WebClient();
            string source = x.DownloadString(@"http://www.google.com");
    
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.Load(source);
    
            foreach(HtmlNode link in document.DocumentElement.SelectNodes("//img")
            {
              image_links[] = link["src"];
           }
    
    
        }
