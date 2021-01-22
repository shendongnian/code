    WebClient client = new WebClient();
    using (XmlReader reader = new SyndicationFeedXmlReader(client.OpenRead(feedUrl)))
    {
        SyndicationFeed feed = SyndicationFeed.Load(reader);
        ....
        //do things with the feed
        ....
    }
