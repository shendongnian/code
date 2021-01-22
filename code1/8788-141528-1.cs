    static IEnumerable Flatten(params object[] objects)
    {
        // Can't easily get varargs behaviour with IEnumerable
        return Flatten((IEnumerable) objects);
    }
        
    static IEnumerable Flatten(IEnumerable enumerable)
    {
        foreach (object element in enumerable)
        {
            IEnumerable candidate = element as IEnumerable;
            if (candidate != null)
            {
                foreach (object nested in candidate)
                {
                    yield return nested;
                }
            }
            else
            {
                yield return element;
            }
        }
    }
