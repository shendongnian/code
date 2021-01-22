    public static IEnumerable<T> OnlyUnique<T>(this IEnumerable<T> source)
    {
        // No error checking :)
        HashSet<T> toReturn = new HashSet<T>();
        HashSet<T> seen = new HashSet<T>();
        
        foreach (T element in source)
        {
            if (seen.Add(element))
            {
                toReturn.Add(element);
            }
            else
            {
                toReturn.Remove(element);
            }
        }
        // yield to get deferred execution
        foreach (T element in toReturn)
        {
            yield return element;
        }
    }
