    public static bool IsOrdered<T>(this IList<T> list, IComparer<T> comparer = null)
	{
		if (comparer == null)
		{
			comparer = Comparer<T>.Default;
		}
		if (list.Count > 1)
		{
			for (int i = 1; i < list.Count; i++)
			{
				if (comparer.Compare(list[i - 1], list[i]) > 0)
				{
					return false;
				}
			}
		}
		return true;
	}
