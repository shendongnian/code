    public static IEnumerable<NewObject> ExtractNewObjects(this Dictionary<int, List<Channel>> dictionary,
         IEnumerable<int> otherChannelIds)
    {
        var channelIdsSet = new  HashSet<int>(otherChannelIds));
        // duplicate channelIds will be removed automatically
        foreach (KeyValuePair<int, List<Channel>> keyValuePair in dictionary)
        {
            // is any ChannelId in the list also in otherChannelIdsSet?
            // every keyValuePair.Value is a List<Channel>
            // every Channel has a ChannelId
            // channelId found if any of these ChannelIds in in the HashSet
            bool channelIdFound = keyValuePair.Value
               .Any(channel => otherChannelIdsSet.Contains(channel.ChannelId);
            if (channelIdFound)
            {
                yield return new NewObject()
                {
                    NewObjectYear = keyValuePair.Key,
                    NewObjectName = keyValuePair.Value
                                    .Select(channel => channel.ChannelName)
                                    .FirstOrDefault(),
                };
            }
        }
    }
