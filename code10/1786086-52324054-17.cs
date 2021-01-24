	public class BlockingCollectionEnumerable<T> : IEnumerable<T>
	{
		public event EventHandler<EventArgs<T>> ItemTaken;
		
		readonly BlockingCollection<T> collection;
		
		public BlockingCollectionEnumerable(BlockingCollection<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException();
			this.collection = collection;
		}
	
        public IEnumerator<T> GetEnumerator()
        {
			while (!collection.IsCompleted)
			{
				var item = default(T);
				try
				{
					item = collection.Take();
					var itemTaken = ItemTaken;
					if (itemTaken != null)
						itemTaken(this, new EventArgs<T>(item));
				}
				catch (InvalidOperationException) 
				{
					yield break;
				}
				
				yield return item;
			}
		}
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
	}
	public class EventArgs<T> : EventArgs
	{
		public T Value { get; private set; }
		public EventArgs(T val) { Value = val; }
	}
