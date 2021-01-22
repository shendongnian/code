    static Dictionary<int, string[]> MergeArrays(
        int[] idCollection,
        params string[][] valueCollections)
    {
        var ret = new Dictionary<int, string[]>();
        for (int i=0; i < idCollection.Length; i++)
        {
             ret[idCollection[i]] = valueCollections.Select
                 (array => array[i]).ToArray();
        }
        return ret;
    }
