    public static string ToCSVList<T>(this IEnumerable<T> collection)
    { return string.Join(",", collection.Select(x => x.ToString()).ToArray()); }
    public static string ToCSVList(this IEnumerable<AssetDocument> assets)
    { return assets.Select(a => a.AssetID).ToCSVList(); }
    public static string ToCSVList(this IEnumerable<PersonDocument> persons)
    { return persons.Select(p => p.PersonID).ToCSVList(); }
