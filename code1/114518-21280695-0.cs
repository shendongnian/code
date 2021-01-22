    var dictionary = new SortedDictionary<int, SortedDictionary<string, List<string>>>();
    var insertAt = 10;
    var newValues = dictionary.ToDictionary(
        x => x.Key < insertAt ? x.Key : x.Key + 1,
        x => x.Value);
    return new SortedDictionary<int, SortedDictionary<string, List<string>>>(newValues); 
