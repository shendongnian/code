    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source)
    {
    	if (!source.Any())
    	{
    		yield break;
    	}
    	Queue<T> items = new Queue<T>();
    	items.Enqueue(source.First());
    	foreach(T item in source.Skip(1))
    	{
    		yield return items.Dequeue();
    		items.Enqueue(item);
    	}
    }
