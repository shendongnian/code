    ServerConnection serverConnection = new ServerConnection(
    new ConnectionProperties
    {
        ServerHostName = "MyHistorianHostName",
        Username = "MyUserName",
        Password = "MyPassword",
        ServerCertificateValidationMode = CertificateValidationMode.None
    });
    serverConnection.Connect();
    if (serverConnection.IsConnected())
    {
        List<Tag> tagList = new List<Tag>();
        TagQueryParams tagQueryParams = new TagQueryParams
        {
            Criteria = new TagCriteria { TagnameMask = "*" }, // Wilcard, get all tags.
            Categories = Tag.Categories.All, // Change this to Basic fo mimimal info.
            PageSize = 100 // The batch size of the while loop below..
        };
    
        bool isQuery = true;
        while (isQuery)
        {
            isQuery = serverConnection.ITags.Query(ref tagQueryParams, out var tags);
            tagList.AddRange(tags);
        }
    
        // At this point, tagList contains a list of all tags that matched your wildcard filter.
        // To filter to a specific collector, you could then do something like:
        var collectorTagList = tagList.Where(t => t.CollectorName == "MyCollector");
    }
