    if (!dictionary.ContainsKey(user.GroupId)
    {
        dictionary.TryAdd(user.GroupId, new HashSet<string>());
    }
    var groups = dictionary[user.GroupId];
    lock(groups)
    {
        groups.Add(user.Id.ToString())
    }
