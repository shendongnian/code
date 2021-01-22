	public interface IEnumAndCount<out T> : IEnumerable<T>
	{
		int Count { get; }
	}
	public class ObservableCollectionForFastEnumDerivedCount<T> : 
		ObservableCollection<T>, IEnumAndCount<T>
	{
	}
