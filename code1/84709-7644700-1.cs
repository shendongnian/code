    using System.ServiceModel.Syndication;
    public static SyndicationFeed GetFeed(string uri)
        {
            if (!string.IsNullOrEmpty(uri))
            {
                var ff = new Rss20FeedFormatter(); // for Atom you can use Atom10FeedFormatter()
                var xr = XmlReader.Create(uri);
                ff.ReadFrom(xr);
                return ff.Feed;             
            }
            return null;
        }
