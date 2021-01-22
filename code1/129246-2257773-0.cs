    public static IList<T> ToListIfNotNullOrEmpty<T>(this IEnumerable<T> value)
    {
        if(value == null)
        {
            return null;
        }
        var result = value.ToList();        
        return result.IsNullOrEmpty() ? null : result;
    }
