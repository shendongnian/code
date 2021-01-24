    public class ConcurrentUniqueStack<T>
	{
		private readonly ConcurrentDictionary<T, int> _itemUnique; // there is no ConcurrentHashSet so we need to use a Key-only dictionary
		private readonly ConcurrentStack<T> _stack;
		public ConcurrentUniqueStack() : this(EqualityComparer<T>.Default)
		{
		}
		public ConcurrentUniqueStack(IEqualityComparer<T> comparer)
		{
			_stack = new ConcurrentStack<T>();
			_itemUnique = new ConcurrentDictionary<T, int>(comparer);
		}
		public bool TryPush(T item)
		{
			bool unique = _itemUnique.TryAdd(item, 1);
			if (unique)
			{
				_stack.Push(item);
			}
			return unique;
		}
		public bool TryPop(out T result)
		{
			bool couldBeRemoved = _stack.TryPop(out result);
			if (couldBeRemoved)
			{
				_itemUnique.TryRemove(result, out int whatever);
			}
			return couldBeRemoved;
		}
	}
