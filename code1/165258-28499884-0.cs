    public override void ItemAdding(SPItemEventProperties properties)
    {
        base.ItemAdding(properties);
        string currTitle = properties.AfterProperties["vti_title"] as string;
        string url = properties.AfterUrl;
        var name = url.Substring(url.LastIndexOf('/') + 1);
        //NOTE! Name is only copied to Title if title is not set. Will not handle name changes!
        if (string.IsNullOrEmpty(currTitle))
        {
            properties.AfterProperties["vti_title"] = name;
        }
    }
