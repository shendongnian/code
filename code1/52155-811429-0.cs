	public static void Push<T>(this IList<T> list, T item)
	{
		list.InsertAt(0, item);
	}
	public static T Pop<T>(this IList<T> list)
	{
		if(list.Count > 0)
		{
			T value = list[0];
			list.RemoveAt(0);
			return value;
		}
		// handle error
	}
