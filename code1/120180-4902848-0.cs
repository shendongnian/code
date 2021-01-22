    public class ReadOnlyObservableList<T> 
            : ReadOnlyObservableCollection<T>, IReadOnlyObservableList<T>
    {
        public ReadOnlyObservableList(ObservableCollection<T> list)
            : base(list)
        {
        }
        public new event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { base.CollectionChanged += value; }
            remove { base.CollectionChanged -= value; }
        }
        public new event PropertyChangedEventHandler PropertyChanged
        {
            add { base.PropertyChanged += value; }
            remove { base.PropertyChanged -= value; }
        }
    }
