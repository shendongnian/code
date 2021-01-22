	public static class IListExtensions
	{
		public static void Sort<T>(this IList<T> list)
		{
			if (list is List<T>)
			{
				((List<T>)list).Sort();
			}
			else
			{
				List<T> copy = new List<T>(list);
				copy.Sort();
				Copy(copy, list);
			}
		}
		public static void Sort<T>(this IList<T> list, Comparison<T> comparison)
		{
			if (list is List<T>)
			{
				((List<T>)list).Sort(comparison);
			}
			else
			{
				List<T> copy = new List<T>(list);
				copy.Sort(comparison);
				Copy(copy, list);
			}
		}
		public static void Sort<T>(this IList<T> list, IComparer<T> comparer)
		{
			if (list is List<T>)
			{
				((List<T>)list).Sort(comparer);
			}
			else
			{
				List<T> copy = new List<T>(list);
				copy.Sort(comparer);
				Copy(copy, list);
			}
		}
		public static void Sort<T>(this IList<T> list, int index, int count, IComparer<T> comparer)
		{
			if (list is List<T>)
			{
				((List<T>)list).Sort(index, count, comparer);
			}
			else
			{
				List<T> copy = new List<T>(list);
				copy.Sort(index, count, comparer);
				Copy(copy, list);
			}
		}
		
		private static void Copy(IList<T> src, IList<T> dst)
		{
			for (int i = 0; i < src.Count; i++)
			{
				dst[i] = src[i];
			}
		}
	}
