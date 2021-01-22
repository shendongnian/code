    HttpWebRequest webRequest   = WebRequest.Create("http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master") as HttpWebRequest;
    
    using (Stream stream = webRequest.GetResponse().GetResponseStream())
    {
        XmlReaderSettings settings  = new XmlReaderSettings();
        settings.IgnoreComments     = true;
        settings.IgnoreWhitespace   = true;
    
        using(XmlReader reader = XmlReader.Create(stream, settings))
        {
            SyndicationFeed feed    = SyndicationFeed.Load(reader);
    
            foreach(SyndicationItem item in feed.Items)
            {
                // Get values of syndication extension elements for a given namespace
                string extensionNamespaceUri            = "http://www.itunes.com/dtds/podcast-1.0.dtd";
                SyndicationElementExtension extension   = item.ElementExtensions.Where<SyndicationElementExtension>(x => x.OuterNamespace == extensionNamespaceUri).FirstOrDefault();
                XPathNavigator dataNavigator            = new XPathDocument(extension.GetReader()).CreateNavigator();
    
                XmlNamespaceManager resolver    = new XmlNamespaceManager(dataNavigator.NameTable);
                resolver.AddNamespace("itunes", extensionNamespaceUri);
    
                XPathNavigator authorNavigator      = dataNavigator.SelectSingleNode("itunes:author", resolver);
                XPathNavigator subtitleNavigator    = dataNavigator.SelectSingleNode("itunes:subtitle", resolver);
                XPathNavigator summaryNavigator     = dataNavigator.SelectSingleNode("itunes:summary", resolver);
                XPathNavigator durationNavigator    = dataNavigator.SelectSingleNode("itunes:duration", resolver);
    
                string author   = authorNavigator != null ? authorNavigator.Value : String.Empty;
                string subtitle = subtitleNavigator != null ? subtitleNavigator.Value : String.Empty;
                string summary  = summaryNavigator != null ? summaryNavigator.Value : String.Empty;
                string duration = durationNavigator != null ? durationNavigator.Value : String.Empty;
    
                // Get attributes of <enclosure> element
                foreach (SyndicationLink enclosure in item.Links.Where<SyndicationLink>(x => x.RelationshipType == "enclosure"))
                {
                    Uri url             = enclosure.Uri;
                    long length         = enclosure.Length;
                    string mediaType    = enclosure.MediaType;
                }
            }
        }
    }
