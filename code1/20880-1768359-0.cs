    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Xml;
    using System.Xml.Linq;
---------------
    SyndicationFeed feed = reader.Read();
    
    foreach (var item in feed.Items)
    {
        foreach (SyndicationElementExtension extension in item.ElementExtensions)
        {
            XElement ele = extension.GetObject<XElement>();
            Console.WriteLine(ele.Value);
        }
    }
