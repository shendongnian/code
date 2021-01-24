    static class Extensions
    {
    	public static Table ToTable<T>(this IEnumerable<T> collection) where T: Row
    	{
    		Table table = new Table();
    		table.AddRange(collection);
    		return table;
    	}
    }
