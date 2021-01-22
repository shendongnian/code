	public static class SortBySample
	{
		public static BySampleSorter<TKey> Create<TKey>(IEnumerable<TKey> fixedOrder, IEqualityComparer<TKey> comparer = null)
		{
			return new BySampleSorter<TKey>(fixedOrder, comparer);
		}
	
		public static BySampleSorter<TKey> Create<TKey>(IEqualityComparer<TKey> comparer, params TKey[] fixedOrder)
		{
			return new BySampleSorter<TKey>(fixedOrder, comparer);
		}
	
		public static IOrderedEnumerable<TSource> OrderBySample<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, BySampleSorter<TKey> sample)
		{
			return sample.OrderBySample(source, keySelector);
		}
	
		public static IOrderedEnumerable<TSource> ThenBySample<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, BySampleSorter<TKey> sample)
		{
			return sample.ThenBySample(source, keySelector);
		}
	}
	public class BySampleSorter<TKey>
	{
		private readonly Dictionary<TKey, int> dict;
	
		public BySampleSorter(IEnumerable<TKey> fixedOrder, IEqualityComparer<TKey> comparer = null)
		{
			this.dict = fixedOrder
				.Select((key, index) => new KeyValuePair<TKey, int>(key, index))
				.ToDictionary(kv => kv.Key, kv => kv.Value, comparer ?? EqualityComparer<TKey>.Default);
		}
	
		public BySampleSorter(IEqualityComparer<TKey> comparer, params TKey[] fixedOrder)
			: this(fixedOrder, comparer)
		{
		}
	
		public IOrderedEnumerable<TSource> OrderBySample<TSource>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.OrderBy(item => this.GetOrderKey(keySelector(item)));
		}
	
		public IOrderedEnumerable<TSource> ThenBySample<TSource>(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.CreateOrderedEnumerable(item => this.GetOrderKey(keySelector(item)), Comparer<int>.Default, false);
		}
	
		private int GetOrderKey(TKey key)
		{
			int index;
			return dict.TryGetValue(key, out index) ? index : int.MaxValue;
		}
	}
