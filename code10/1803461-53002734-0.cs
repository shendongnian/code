    IEnumerable<Account> FindByPartialId(Dictionary<ulong, Account> dictionary, ulong partialId)
    {
        var partialIdAsString = partialId.ToString();
        var matchingKeys = dictionary.Keys.Where(k => k.ToString().StartsWith(partialIdAsString));
        var matchingValues = matchingKeys.Select(k => dictionary[k]);
        return matchingValues;
    }
