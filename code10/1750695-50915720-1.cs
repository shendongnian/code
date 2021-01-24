	static public class ExtensionMethods
	{
		static public bool HasDuplicates<TItem,TKey>(this IEnumerable<TItem> source, Func<TItem,TKey> func)
		{
			var found = new HashSet<TKey>();
			foreach (var key in source.Select(func))
			{
				if (found.Contains(key)) return true;
				found.Add(key);
			}
			return false;
		}
	}
