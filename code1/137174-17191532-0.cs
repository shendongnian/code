    	/// <summary>
	/// Extension methods for <see cref="System.Collections.Generic.List{T}"/>
	/// </summary>
	public static class ListExtensions
	{
		public static void MoveForward<T>(this List<T> list, Predicate<T> itemSelector, bool isLastToBeginning)
		{
			Ensure.ArgumentNotNull(list, "list");
			Ensure.ArgumentNotNull(itemSelector, "itemSelector");
			var currentIndex = list.FindIndex(itemSelector);
			
			// Copy the current item
			var item = list[currentIndex];
			bool isLast = list.Count - 1 == currentIndex;
			if (isLastToBeginning && isLast)
			{
				// Remove the item
				list.RemoveAt(currentIndex);
				// add the item to the beginning
				list.Insert(0, item);
			}
			else if (!isLast)
			{
				// Remove the item
				list.RemoveAt(currentIndex);
				// add the item at next index
				list.Insert(currentIndex + 1, item);
			}
		}
		public static void MoveBack<T>(this List<T> list, Predicate<T> itemSelector, bool isFirstToEnd)
		{
			Ensure.ArgumentNotNull(list, "list");
			Ensure.ArgumentNotNull(itemSelector, "itemSelector");
			var currentIndex = list.FindIndex(itemSelector);
			// Copy the current item
			var item = list[currentIndex];
			bool isFirst = 0 == currentIndex;
			if (isFirstToEnd && isFirst)
			{
				// Remove the item
				list.RemoveAt(currentIndex);
				// add the item to the end
				list.Add(item);				
			}
			else if (!isFirstToEnd)
			{
				// Remove the item
				list.RemoveAt(currentIndex);
				// add the item to previous index
				list.Insert(currentIndex - 1, item);
			}
		}
	}
