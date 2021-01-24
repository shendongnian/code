    public class Solution3<T> : ObservableCollection<T>
    {
        public sealed override event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { base.CollectionChanged += value; }
            remove { base.CollectionChanged -= value; }
        }
        ...
    }
