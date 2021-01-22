	/// Select from start to end exclusive of end using the same semantics
	/// as python slice.
	/// <param name="list"> the list to slice</param>
	/// <param name="start">The starting index</param>
	/// <param name="end">The ending index. The result does not include this index</param>
	public static List<T> Slice<T>
	(this IReadOnlyList<T> list, int start, int? end = null)
	{
	    if (end == null)
	    {
	        end = list.Count();
	    }
	     if (start < 0)
	    {
	        start = list.Count + start;
	    }
	     if (start >= 0 && end.Value > 0 && end.Value > start)
	    {
	        return list.GetRange(start, end.Value - start);
	    }
	     if (end < 0)
	    {
	        return list.GetRange(start, (list.Count() + end.Value) - start);
	    }
	     if (end == start)
	    {
	        return new List<T>();
	    }
	     throw new IndexOutOfRangeException(
	        "count = " + list.Count() + 
	        " start = " + start +
	        " end = " + end);
	}
