	public static class LinqExtensions
	{
		public static ICollection<T> AddRange<T>(this ICollection<T> source, IEnumerable<T> addSource)
		{
			foreach(T item in addSource)
			{
				source.Add(item);
			}
			return source;
		}
	}
	public class ExtendedObservableCollection<T>: ObservableCollection<T>
	{
		public void Execute(Action<IList<T>> itemsAction)
		{
			itemsAction(Items);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}
