    public sealed class Solution2<T> : ObservableCollection<T>
    {
        public Solution2()
        {
            this.CollectionChanged += new NotifyCollectionChangedEventHandler(ObsCol_CollectionChanged);
        }
        ...
    }
