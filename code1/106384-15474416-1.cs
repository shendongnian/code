    public interface INotifyCollection<T> 
           : ICollection<T>, 
             INotifyCollectionChanged
    {}
    public interface IReadOnlyNotifyCollection<out T> 
           : IReadOnlyCollection<T>, 
             INotifyCollectionChanged
    {}
    public class NotifyCollection<T> 
           : ObservableCollection<T>, 
             INotifyCollection<T>, 
             IReadOnlyNotifyCollection<T>
    {}
    public class Program
    {
        private static void Main(string[] args)
        {
            var full = new NotifyCollection<string>();
            var readOnlyAccess = (IReadOnlyCollection<string>) full;
            var readOnlyNotifyOfChange = (IReadOnlyNotifyCollection<string>) full;
            //Covarience
            var readOnlyListWithChanges = 
                new List<IReadOnlyNotifyCollection<object>>()
                    {
                        new NotifyCollection<object>(),
                        new NotifyCollection<string>(),
                    };
        }
    }
