	public static class IListExtensions
	{
		public static void Sort<T>(this IList<T> list)
		{
			List<T> copy = new List<T>(list);
			copy.Sort();
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = copy[i];
			}
		}
		public static void Sort<T>(this IList<T> list, IComparer<T> comparer)
		{
			List<T> copy = new List<T>(list);
			copy.Sort(comparer);
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = copy[i];
			}
		}
		public static void Sort<T>(this IList<T> list, Comparison<T> comparison)
		{
			List<T> copy = new List<T>(list);
			copy.Sort(comparison);
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = copy[i];
			}
		}
		public static void Sort<T>(this IList<T> list, int index, int count, IComparer<T> comparer)
		{
			List<T> copy = new List<T>(list);
			copy.Sort(index, count, comparer);
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = copy[i];
			}
		}
	}
