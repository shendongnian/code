    static IEnumerable<T> OrderBySequence<T>(IEnumerable<T> source, IEnumerable<Int32> sequence)
    {
    	for (var i = 0; i < Math.Min(source.Count(), sequence.Count()); i++)
    	{
    		var s = sequence.ElementAt(i);
    		if (s > -1 && s < source.Count())
    		{
    			yield return source.ElementAt(s);
    		}
    	}
    }
