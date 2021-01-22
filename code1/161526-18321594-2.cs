    public static IEnumerable<TSource> ExceptAll<TSource>(
        this IEnumerable<TSource> first,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource> comparer)
    {
        if (first == null) { throw new ArgumentNullException("first"); }
        if (second == null) { throw new ArgumentNullException("second"); }
        var secondCounts = new Dictionary<TSource, int>(comparer ?? EqualityComparer<TSource>.Default);
        int count;
            
        // Count the values of second
        foreach (var item in second)
        {
            if (secondCounts.TryGetValue(item, out count))
            {
                // If you replace the stuct int with a class that counts,
                // the lookup here is not needed as you have a reference to the object
                // Disadvantage: it add a lot of objects to create and be collected 
                secondCounts[item] = count + 1;
            }
        }
            
        // Yield the values of first
        foreach (var item in first)
        {
            if (secondCounts.TryGetValue(item, out count))
            {
                if (count == 0)
                {
                    secondCounts.Remove(item);
                }
                else
                {
                    // If you replace the stuct int with a class that counts,
                    // the lookup here is not needed as you have a reference to the object
                    // Disadvantage: it add a lot of objects to create and be collected 
                    secondCounts[item] = count - 1;
                }
            }
            else
            {
                yield return item;
            }
        }
    }
