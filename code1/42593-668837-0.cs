    private static SyndicationFeed CreateFeed(List<SyndicationItem> items)
    {
        // Create the list of syndication items. These correspond to Atom entries
        SyndicationFeed feed;
    
        // create the feed containing the syndication items.
        feed = new SyndicationFeed()
        {
            // The feed must have a unique stable URI id
            Id = "http://example.com/MyFeed",
            Title = new TextSyndicationContent("My Feed"),
            Items = items
        };
        feed.AddSelfLink(WebOperationContext.Current.IncomingRequest.GetRequestUri());
        return feed;
    }
    
    private static SyndicationItem CreateItem()
    {
        var item = new SyndicationItem()
           {
               // Every entry must have a stable unique URI id
               Id = id.ToString(),
               Title = new TextSyndicationContent(title),
               // Every entry should include the last time it was updated
               LastUpdatedTime = startDate,
               // The Atom spec requires an author for every entry. If the entry has no author, use the empty string
               Authors = 
                   { 
                       new SyndicationPerson() 
                           {
                               Name = author.Name,
                               Email = author.EmailAddress,
                               Uri = author.Website
                           }
                   },
               // The content of an Atom entry can be text, xml, a link or arbitrary content. In this sample text content is used.
               Content = new TextSyndicationContent(description),
           };
        
        return item;
    }
