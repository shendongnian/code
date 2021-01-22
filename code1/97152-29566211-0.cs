    public static IEnumerable<T> AsSingletonOrEmpty<T>(this T source)
    {
        if (source == null)
        {
            yield break;
        }
        else
        {
            yield return source;
        }
    }
    public static IEnumerable<T> AsSingleton<T>(this T source)
    {
        yield return source;
    }
