    var anotherListIDs = new HashSet<int>(anotherList.Select(c => c.ChannelId));            
    foreach (var x in myDictionary)
    {
        list.AddRange(x.Value
            .Where(c => anotherListIDs.Contains(c.ChannelId))
            .Select(c => new NewObject
            {
                NewObjectYear = x.Key,
                NewObjectName = c.First().ChannelName,
            }));
    }
