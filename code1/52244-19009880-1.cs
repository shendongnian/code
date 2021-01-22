    IEnumerable<T> Convert<T>(IEnumerable source, T firstItem)
    {
        // Note: firstItem parameter is unused and is just for resolving type of T
    	foreach(var item in source)
    	{
    		yield return (T)item;
    	}
    }
    
    void Method(IEnumerable source)
    {
        var enumerator = source.GetEnumerator();
    
        if (enumerator.MoveNext())
        {
    		dynamic firstItem = enumerator.Current;
    		dynamic typedEnumerable = Convert(source, firstItem);
            Method2(typedEnumerable);
        }
    }
