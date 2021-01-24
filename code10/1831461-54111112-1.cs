    public static class Extensions
    {
    	public static string SplitAndSort(this IEnumerable<string> source)
    	{
    		var list = source.Where(x=>x!=null)
                             .SelectMany(c=>c.Split(new[]{";"},StringSplitOptions.RemoveEmptyEntries))
                             .Distinct()
                             .OrderBy(x=>x);
    		return string.Join(";",list);
    	}
    }
