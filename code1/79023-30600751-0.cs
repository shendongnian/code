    public static class Misc
    	{
    		public static void SyncCollection<TCol,TEnum>(ICollection<TCol> collection,IEnumerable<TEnum> source, Func<TCol,TEnum,bool> comparer, Func<TEnum, TCol> converter )
    		{
    			var missing = collection.Where(c => !source.Any(s => comparer(c, s))).ToArray();
    			var added = source.Where(s => !collection.Any(c => comparer(c, s))).ToArray();
    
    			foreach (var item in missing)
    			{
    				collection.Remove(item);
    			}
    			foreach (var item in added)
    			{
    				collection.Add(converter(item));
    			}
    		}
    		public static void SyncCollection<T>(ICollection<T> collection, IEnumerable<T> source, EqualityComparer<T> comparer)
    		{
    			var missing = collection.Where(c=>!source.Any(s=>comparer.Equals(c,s))).ToArray();
    			var added = source.Where(s => !collection.Any(c => comparer.Equals(c, s))).ToArray();
    
    			foreach (var item in missing)
    			{
    				collection.Remove(item);
    			}
    			foreach (var item in added)
    			{
    				collection.Add(item);
    			}
    		}
    		public static void SyncCollection<T>(ICollection<T> collection, IEnumerable<T> source)
    		{
    			SyncCollection(collection,source, EqualityComparer<T>.Default);
    		}
    	}
