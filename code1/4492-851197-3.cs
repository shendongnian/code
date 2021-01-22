        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var i in collection) Items.Add(i);
            OnPropertyChanged("Count");
            OnPropertyChanged("Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
 
