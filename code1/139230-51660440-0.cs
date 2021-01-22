    public static IEnumerable<T> FindMissing<T>(IEnumerable<T> superset, IEnumerable<T> subset) where T : IComparable
    {
        bool include = true;
        foreach (var i in superset)
        {
            foreach (var j in subset)
            {
                include = i.CompareTo(j) == 0;
                if (include)
                    break;
            }
            if (!include)
                yield return i;
        }
    }
   
