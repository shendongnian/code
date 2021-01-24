    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls12;
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
            System.Net.WebResponse myResponse = myRequest.GetResponse();
    
    try
    {
            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();
    
            rssDoc.Load(rssStream);
    
            System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss /channel/item");
      //Matrix, 100 rows , 3 colums
            String[,] tempRssData = new String[100, 3];
    }
    Catch(Exception ex)
    {
    }
     
     
