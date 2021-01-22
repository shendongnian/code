    public static class EnumerableUtils
	{
		[DebuggerDisplay("Key: {Key}")]
		private class KeyEnumerator<TKey> : IComparable<KeyEnumerator<TKey>>
		{
			public KeyEnumerator(
				TKey key,
				IEnumerator<TKey> enumerator,
				IComparer<TKey> comparer)
			{
				Enumerator = enumerator;
				KeyComparer = comparer;
				Key = key;
			}
			public TKey Key { get; private set; }
			public IEnumerator<TKey> Enumerator { get; private set; }
			public IComparer<TKey> KeyComparer { get; private set; }
			public int CompareTo(KeyEnumerator<TKey> other)
			{
				return KeyComparer.Compare(Key, other.Key);
			}
		}
		public static IEnumerable<T> Merge<T>(
			IEnumerable<IEnumerable<T>> listOfLists,
			Func<T, T, int> comparison = null)
		{
			IComparer<T> cmp = comparison != null
				? Comparer<T>.Create(new Comparison<T>(comparison))
				: Comparer<T>.Default;
			List<IEnumerator<T>> es = listOfLists
				.Select(l => l.GetEnumerator())
				.Where(e => e.MoveNext())
				.ToList();
			var bag = new OrderedBag<KeyEnumerator<T>>();
			es.ForEach(e => bag.Add(new KeyEnumerator<T>(e.Current, e, cmp)));
			while (bag.Count > 0)
			{
				KeyEnumerator<T> kv = bag.RemoveFirst();
				IEnumerator<T> e = kv.Enumerator;
				yield return e.Current;
				if (e.MoveNext())
				{
					bag.Add(new KeyEnumerator<T>(e.Current, e, cmp));
				}
			}
		}
    }
