    /// <summary>
	/// Comparer for comparing two keys, handling equality as being greater
	/// Use this Comparer e.g. with SortedSets, SortedLists or SortedDictionaries, that don't allow duplicate keys
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
	{
		#region IComparer<TKey> Members
		public int Compare(TKey x, TKey y)
		{
			int result = x.CompareTo(y);
			return result == 0 ? 1 : result; // Handle equality as being greater
		}
		#endregion
	}
