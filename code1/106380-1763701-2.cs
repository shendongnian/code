    public interface IIndexerCollection<T> : IEnumerable<T>
    {
        T this[int i]
        {
            get;
        }
    }
    
    public class IndexCollection<T> : ObservableCollection<T>, IIndexerCollection<T>
    {
    }
