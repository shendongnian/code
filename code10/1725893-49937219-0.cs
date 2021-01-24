    public interface IMyInterface
    {
        IEnumerable<object> Items { get; }
    }
    public interface IMyInterface<TValue> : IMyInterface
    {
        new ObservableCollection<TValue> Items { get; } //Try to override base Items
    }
    public abstract class MyBase<T> : IMyInterface<T> where T : class
    {
        private ObservableCollection<T> _Items;
        public ObservableCollection<T> Items
        {
            get
            {
                return _Items;
            }
        }
        IEnumerable<object> IMyInterface.Items
        {
            get
            {
                return _Items;
            }
        }
    }
