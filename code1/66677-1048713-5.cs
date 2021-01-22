    public static void Do<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T item in collection)
        {
            action(item);
        }
    }
    public static IEnumerable<Int32> Range(Int32 start, Int32 end, Int32 step)
    {
        for (int i = start; i < end; i += step)
        }
            yield return i;
        }
    }
