		public static void AddNew<T>(this List<T> l, T item, int maxAmount)
		{
			
			l.Add(item);
			if (l.Count >= maxAmount)
			{
				l.RemoveRange(maxAmount, l.Count - maxAmount);
			}
		}
