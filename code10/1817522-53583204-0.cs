	bool IsEmpty<T>(ref IEnumerable<T> source)
	{
		if (source is ICollection<T> collection)
		{
			return collection.Count == 0;
		}
	    var enumerator = source.GetEnumerator();
	    if (enumerator.MoveNext())
	    {
	        source = CreateIEnumerable(enumerator);
	        return false;
	    }
        usedEnumerator.Dispose();
	    return true;
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
