    public class SmartCollection<T> : ObservableCollection<T>
    {
        public T FirstItem => Items.Count > 0 ? Items[0] : default(T);
        public SmartCollection()
            : base()
        {
        }
        public SmartCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }
        public SmartCollection(List<T> list)
            : base(list)
        {
        }
        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
            {
                Items.Add(item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("FirstItem"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public void Reset(IEnumerable<T> range)
        {
            this.Items.Clear();
            AddRange(range);
        }
    }
