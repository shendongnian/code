    public static class ListExtensions
    {
    	public static List<T> Slice<T>(this List<T> list, int? start = null, int? end = null)
    	{
    		if (start.HasValue)
    			return list.GetRange(start.Value, (end.HasValue ? (end.Value + 1) : list.Count) - start.Value);
    		if (end.HasValue) // not sure [:n] returns last n elements?
    			return list.GetRange(list.Count - end.Value, end.Value);
    			
    		return list;
    	}
    }
    var list1 = new List<string> { "lets", "go", "visit", "houston", "texas" };
	list1.Slice(3) // houston, texas 
	list1.Slice(3, 4) // houston, texas
	list1.Slice(null, 3) // visit, houston, texas
