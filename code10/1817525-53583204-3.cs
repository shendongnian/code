	IEnumerable<T> NotEmpty<T>(IEnumerable<T> source)
	{
		if (source is ICollection<T> collection)
		{
			if (collection.Count == 0)
			{
			   return null;
			}
			return source;
		}
	    var enumerator = source.GetEnumerator();
	    if (enumerator.MoveNext())
	    {
	        return CreateIEnumerable(enumerator);
	    }
        enumerator.Dispose();
	    return null;
	    IEnumerable<T> CreateIEnumerable(IEnumerator<T> usedEnumerator)
	    {
	        yield return usedEnumerator.Current;
		    while (usedEnumerator.MoveNext())
	        {
	            yield return usedEnumerator.Current;
	        }
			usedEnumerator.Dispose();
	    }
	}
