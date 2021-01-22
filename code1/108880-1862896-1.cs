    // load the raw feed
    using (var xmlr = XmlReader.Create("http://stackoverflow.com/feeds/question/1813559"))
    {
        // get the items within a feed
        var feedItems = SyndicationFeed
                            .Load(xmlr)
                            .GetRss20Formatter()
                            .Feed
                            .Items;
        
        // print out details about each item in the feed
        foreach (var item in feedItems)
        {
            Console.WriteLine("Title: {0}", item.Title.Text); 
            Console.WriteLine("Author: {0}", item.Authors.First().Name);
            Console.WriteLine("Id: {0}", item.Id);
            
            // the extensions assume that there can be more than one value, so get
            // the first or default value (default == 0)
            int rank = item.ElementExtensions
                            .ReadElementExtensions<int>("rank", "http://purl.org/atompub/rank/1.0")
                            .FirstOrDefault();
            
            Console.WriteLine("Rank: {0}", rank);  
        }
    }
