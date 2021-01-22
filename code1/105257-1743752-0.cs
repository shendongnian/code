    public static void RemoveAll<T>(this IList<T> list, Predicate<T> match)
    {
        if (list == null)
            throw new ArgumentNullException("list");
        if (match == null)
            throw new ArgumentNullException("match");
        if (list is T[])
            throw new ArgumentException("Arrays cannot be resized.");
        // early out
        if (list.Count == 0)
            return;
        // List<T> provides special handling
        List<T> genericList = list as List<T>;
        if (genericList != null)
        {
            genericList.RemoveAll(match);
            return;
        }
        int targetIndex = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (!match(list[i]) && targetIndex != i)
            {
                list[targetIndex] = list[i];
                targetIndex++;
            }
        }
        // Unfortunately IList<T> doesn't have RemoveRange either
        for (int i = list.Count - 1; i >= targetIndex; i--)
        {
            list.RemoveAt(i);
        }
    }
    public static void RemoveAll<T>(ref T[] array, Predicate<T> match)
    {
        if (array == null)
            throw new ArgumentNullException("array");
        if (match == null)
            throw new ArgumentNullException("match");
        int targetIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (!match(array[i]) && targetIndex != i)
            {
                array[targetIndex] = array[i];
                targetIndex++;
            }
        }
        if (targetIndex != array.Length)
        {
            Array.Resize(ref array, targetIndex);
        }
    }
