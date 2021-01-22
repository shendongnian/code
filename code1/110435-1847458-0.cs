    public static IList<T>[] Split<T>(this IList<T> source, int elementCount)
    {
        // What the heck, it's easy to implement...
        IList<T>[] ret = new IList<T>[(source.Count + elementCount - 1) 
                                      / elementCount];
        for (int i = 0; i < ret.Length; i++)
        {
            int start = i * elementCount;
            int size = Math.Min(elementCount, source.Count - i * start);
            T[] tmp = new T[size];
            // Would like CopyTo with a count, but never mind
            for (int j = 0; i < size; j++)
            {
                tmp[j] = source[j + start];
            }
            ret[i] = tmp;
        }
        return ret;
    }
