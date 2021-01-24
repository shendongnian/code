    public class LimitedSizeObservableCollection<T> : ObservableCollection<T>
	{
		public int Capacity { get; }
		public LimitedSizeObservableCollection(int capacity)
		{
			Capacity = capacity;
		}
		public new void Add(T item)
		{
			if (Count >= Capacity)
			{
				this.RemoveAt(0);
			}
			base.Add(item);
		}
	}
 
