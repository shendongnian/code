    var ns = (XNamespace) "http://search.yahoo.com/mrss/";  // namespace of the extension
    
    SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(@"http://rss.cnn.com/rss/edition.rss"));
    
    var urls = from item in feed.Items              // all items
               from ext in  item.ElementExtensions  // all extensions to ext
               where ext.OuterName == "group" &&    // find the ones called group
                     ext.OuterNamespace == ns       // in the right namespace
               from content in ext.GetObject<XElement>().Elements(ns + "content") // get content elements
               where (string) content.Attribute("medium") == "image"  // if that medium is an image
               select (string) content.Attribute("url");              // get the url
    
    // output what is in urls
    foreach(string url in urls) 
    {
          Console.WriteLine(url);
    }
