    public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool inclusive)
    {
        foreach(T item in source)
        {
            if(predicate(item)) 
            {
                yield return item;
            }
            else
            {
                if(inclusive) yield return item;
    
                yield break;
            }
        }
    } 
