    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.ServiceModel.Syndication;
    
    namespace FeedUnion
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri feedUri = new Uri("http://stackoverflow.com/feeds/tag/silverlight"); 
                SyndicationFeed feed;
                SyndicationFeed feed2;
                using(XmlReader reader = XmlReader.Create(feedUri.AbsoluteUri))
                {
                    feed= SyndicationFeed.Load(reader); 
                }
                Uri feed2Uri = new Uri("http://stackoverflow.com/feeds/tag/wpf"); 
                using (XmlReader reader2 = XmlReader.Create(feed2Uri.AbsoluteUri))
                {
                feed2 = SyndicationFeed.Load(reader2);
                }
                SyndicationFeed feed3 = new SyndicationFeed(feed.Items.Union(feed2.Items));
                StringBuilder builder = new StringBuilder();
                using (XmlWriter writer = XmlWriter.Create(builder))
                {
                    feed3.SaveAsRss20(writer);
                    System.Console.Write(builder.ToString());
                    System.Console.Read();
                }
            }
        }
    }
