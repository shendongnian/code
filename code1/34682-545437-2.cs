    static Dictionary<int, string[]> MergeArrays(
        IEnumerable<int> idCollection,
        params IEnumerable<string>[] valueCollections)
    {
        var valueCollectionArrays = valueCollections.Select
             (x => x.ToArray()).ToArray();
        var indexedIds = idCollection.Select((Id, Index) => new { Index, Id });
    
        return indexedIds.ToDictionary(x => Id, 
            x => valueCollectionArrays.Select(array => array[x.Index]).ToArray());
    }
