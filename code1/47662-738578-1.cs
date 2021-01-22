    public static T First<T>(IEnumerable<T> source)
    {
        foreach (T element in source)
        {
            return element;
        }
        throw new InvalidOperationException("Empty list");
    }
    public static T Last<T>(IEnumerable<T> source)
    {
        T last = default(T);
        bool gotAny = false;
        foreach (T element in source)
        {
            last = element;
            gotAny = true;
        }
        if (!gotAny)
        {
            throw new InvalidOperationException("Empty list");
        }
        return last;
    }
