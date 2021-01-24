	class Grouping<TKey, TElement>
		: IGrouping<TKey, TElement>
	{
		private readonly IEnumerable<TElement> elements;
		public Grouping(TKey key, IEnumerable<TElement> elements)
		{
			this.elements = elements;
			Key = key;
		}
		public TKey Key { get; }
		public IEnumerator<TElement> GetEnumerator() => elements.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => elements.GetEnumerator();
	}
