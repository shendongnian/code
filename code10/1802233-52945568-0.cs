    List<KeyValuePair<int, Dictionary<string, object>>> source = ...
    var result = source
        // keep only those items in the list that have a Dictionary with only one value,
        // namely a Boolean that is true
        .Where(pair => pair.Value.Count == 1 
                    // pair.Value is a Dictionary; 
                    // pair.Value.Values are the values in the Dictionary
                    // only keep this item if the one and only value in the dictionary is a Boolean with a value true
                    && pair.Value.Values.First().GetType() == typeof(bool)
                    && (bool)pair.Value.ValuesFirst());
