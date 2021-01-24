	static public class ExtensionMethods
	{
		static public bool HasDuplicates<TItem,TKey>(this IEnumerable<TItem> This, Func<TItem,TKey> func)
		{
			var found = new HashSet<TKey>();
			foreach (var key in This.Select(func))
			{
				if (found.Contains(key)) return true;
				found.Add(key);
			}
			return false;
		}
	}
