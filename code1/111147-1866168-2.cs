    public static IEnumerable<T> Cast<T>(this IEnumerable source)
    {
       foreach(object element in source)
       {
          yield return (T)(object)element;
       }
    }
