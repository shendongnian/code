    public static K CopyMost<T, K>(this IEnumerable<T> records, Func<T, K> propertySelector, Func<K, bool> tieBreaker)
    {
        var grouped = records.GroupBy(x => propertySelector(x)).Select(x => new { Group = x, Count = x.Count() });
        var maxCount = grouped.Max(x => x.Count);
        var subGroup = grouped.Where(x => x.Count == maxCount);
    
        if (subGroup.Count() == 1)
            return subGroup.Single().Group.Key;
        else
            return subGroup.Where(x => tieBreaker(x.Group.Key)).Single().Group.Key;
    }
