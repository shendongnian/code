    public static string Concatenate(
        this IEnumerable<string> collection, 
        string separator)
    {
        return collection
            .Skip(1)
            .Aggregate(
                new StringBuilder().Append(collection.First()),
                (b, s) => b.Append(separator).Append(s))
            .ToString();
    }
