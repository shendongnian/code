    public static IEnumerable<NewObject> ExtractNewObjects(this Dictionary<int, List<Channel>> dictionary,
         IEnumerable<OtherItem> otherList)
    {
        // I'll only use the ChannelIds of the otherList, so extract them
        IEnumerable<int> otherChannelIds = otherList
            .Select(otherItem => otherItem.ChannelId);
        return dictionary.ExtractNewObjects(otherChannelIds);
    }
