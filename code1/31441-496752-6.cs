    public static IEnumerable<T[]> Zip<T>(params T[][] sources)
    {
        // (Insert error checking code here for null or empty sources parameter)
        int length = sources[0].Length;
        if (!sources.All(array => array.Length == length))
        {
            throw new ArgumentException("Arrays must all be of the same length");
        }
        for (int i=0; i < length; i++)
        {
            // Could do this bit with LINQ if you wanted
            T[] result = new T[sources.Length];
            for (int j=0; j < result.Length; j++)
            {
                 result[j] = sources[j][i];
            }
            yield return result;
        }
    }
