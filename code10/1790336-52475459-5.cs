    public static IEnumerable<TSource> RemoveDuplicates<TSource> (
        this IEnumerable<Tsource> list1,
        IEnumerable<TSource> list2)
    {
        var group1 = list1.GroupBy(item => item)
           .Select(group => new
           {
               value = group.Key,
               count = group.Count(),
           });
        var group2 = list2.GroupBy(item => item)
           .Select(group => new
           .ToDictionary(group => group.Key, group => group.Count());
        // for every item in group1, check if there is a same one in group2.
        // If so, subtract the count and return the remaining items
        foreach (var item in group1)
        {
            // are the also some "a" values in list2?
            if (group2.TryGetValue(item1.Value, out int nrToremove))
            {
                // yes there are: nrToRemove contains the number of "a" values in list2
                int nrToReturn = item.Count - nrToRemove;
                // return all remaining "a" values:
                for (int i=0; i<nrToReturn; ++i)
                {
                    yield return item.Value;  // return an "a"
                }
            }
        }
    }
