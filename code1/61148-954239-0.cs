    /// <summary>
		/// Removes all items from the provided <paramref name="list"/> that match the<paramref name="predicate"/> expression.
		/// </summary>
		/// <typeparam name="T">The class type of the list items.</typeparam>
		/// <param name="list">The list to remove items from.</param>
		/// <param name="predicate">The predicate expression to test against.</param>
		public static void RemoveWhere<T>(this IList<T> list, Func<T, bool> predicate)
		{
			T[] copy = new T[] { };
			Array.Resize(ref copy, list.Count);
			list.CopyTo(copy, 0);
			for (int i = copy.Length - 1; i >= 0; i--)
			{
				if (predicate(copy[i]))
				{
					list.RemoveAt(i);
				}
			}
		}
		/// <summary>
		/// Inserts an Item into a list at the first place that the <paramref name="predicate"/> expression fails.  If it is true in all cases, then the item is appended to the end of the list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="obj"></param>
		/// <param name="predicate">The sepcified function that determines when the <paramref name="obj"/> should be added. </param>
		public static void InsertWhere<T>(this IList<T> list, T obj, Func<T, bool> predicate)
		{
			for (int i = 0; i < list.Count; i++)
			{ 
				// When the fuction first fails it inserts the obj paramiter. 
				// For example, in a list myList of ordered Int32's {1,2,3,4,5,10,12}
				// Calling myList.InsertWhere( 8, x => 8 > x) inserts 8 once the list item becomes greater then or equal to it.
				if(!predicate(list[i]))
				{
					list.Insert(i, obj);
					return;
				}
			}
			list.Add(obj);
		}
