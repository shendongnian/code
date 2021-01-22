    static IEnumerable Flatten(IEnumerable enumerable)
    {
        foreach (object element in enumerable)
        {
            IEnumerable candidate = element as IEnumerable;
            if (candidate != null)
            {
                foreach (object nested in Flatten(candidate))
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
