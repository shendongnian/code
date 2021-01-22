        // url of the feed 
        string utlToload = @"http://feeds.feedburner.com/punchfire?format=xml"
    
        // load feed
            Argotic.Syndication.GenericSyndicationFeed feed = 
    Argotic.Syndication.GenericSyndicationFeed.Create(new Uri(urlToLoad));
    
            // check what format is it
            if (feed.Format.Equals(SyndicationContentFormat.Rss))
            {
                // yourlogic here
            }
            else if (feed.Format.Equals(SyndicationContentFormat.Atom))
            {
                // yourlogic here
            } 
            else if (feed.Format.Equals(SyndicationContentFormat.NewsML))
            {
                // yourlogic here
            } 
