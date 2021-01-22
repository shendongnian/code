    public static class Extensions
    	{
    		/// <summary>
    		/// This would flatten out a recursive data structure ignoring the loops. The end result would be an enumerable which enumerates all the
    		/// items in the data structure regardless of the level of nesting.
    		/// </summary>
     		/// <typeparam name="T">Type of the recursive data structure</typeparam>
	    	/// <param name="source">Source element</param>
    		/// <param name="childrenSelector">a function that returns the children of a given data element of type T</param>
    		/// <param name="keySelector">a function that returns a key value for each element</param>
    		/// <returns>a faltten list of all the items within recursive data structure of T</returns>
     		public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source,
    			Func<T, IEnumerable<T>> childrenSelector,
    			Func<T, object> keySelector) where T : class
    		{
    			if (source == null)
    				throw new ArgumentNullException("source");
    			if (childrenSelector == null)
    				throw new ArgumentNullException("childrenSelector");
    			if (keySelector == null)
    				throw new ArgumentNullException("keySelector");
    			var stack = new Stack<T>( source);
    			var dictionary = new Dictionary<object, T>();
    			while (stack.Any())
    			{
    				var currentItem = stack.Pop();
    				var currentkey = keySelector(currentItem);
    				if (dictionary.ContainsKey(currentkey) == false)
    				{
    					dictionary.Add(currentkey, currentItem);
    					var children = childrenSelector(currentItem);
    					if (children != null)
    					{
    						foreach (var child in children)
    						{
    							stack.Push(child);
    						}
    					}
    				}
    				yield return currentItem;
    			}
    		}
    
    		/// <summary>
    		/// This would flatten out a recursive data structure ignoring the loops. The     end result would be an enumerable which enumerates all the
    		/// items in the data structure regardless of the level of nesting.
    		/// </summary>
     		/// <typeparam name="T">Type of the recursive data structure</typeparam>
    		/// <param name="source">Source element</param>
    		/// <param name="childrenSelector">a function that returns the children of a     given data element of type T</param>
    		/// <param name="keySelector">a function that returns a key value for each   element</param>
    		/// <returns>a faltten list of all the items within recursive data structure of T</returns>
    		public static IEnumerable<T> Flatten<T>(this T source, 
    			Func<T, IEnumerable<T>> childrenSelector,
    			Func<T, object> keySelector) where T: class
    		{
    			return Flatten(new [] {source}, childrenSelector, keySelector);
    		}
    	}
