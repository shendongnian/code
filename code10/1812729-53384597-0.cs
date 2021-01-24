    var dictionary = new ConcurrentDictionary<int, ConcurrentBag<string>>();
    var grouppedUsers = users.GroupBy(u => u.GroupId);
    foreach (var group in grouppedUsers)
    {
        // get the bag from the dictionary or create it if it doesn't exist
        var currentBag = dictionary.GetOrAdd(group.Key, new ConcurrentBag<string>());
        // load it with the users required
        foreach (var user in group)
        {
            if (!currentBag.Contains(user.Id.ToString())
            {
                currentBag.Add(user.Id.ToString());
            }
        }
    }
