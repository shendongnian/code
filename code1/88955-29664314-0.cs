    public class SpecialObservableCollection<T> : ObservableCollection<T>
    {
        public SpecialObservableCollection()
        {
            this.CollectionChanged += OnCollectionChanged;
        }
        void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null) {AddOrRemoveListToPropertyChanged(e.NewItems,true);  }
            if (e.OldItems != null) {AddOrRemoveListToPropertyChanged(e.NewItems,false); }
        }
        private void AddOrRemoveListToPropertyChanged(IList list, Boolean add)
        {
            if (list == null) { return; }
            foreach (object item in list)
            {
                INotifyPropertyChanged o = item as INotifyPropertyChanged;
                if (o != null)
                {
                    if (add)  { o.PropertyChanged += ListItemPropertyChanged; }
                    if (!add) { o.PropertyChanged -= ListItemPropertyChanged; }
                }
                else
                {
                    throw new Exception("INotifyPropertyChanged is required");
                }
            }
        }
        
        void ListItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnListItemChanged(this, e);
        }
        public delegate void ListItemChangedEventHandler(object sender, PropertyChangedEventArgs e);
        
        public event ListItemChangedEventHandler ListItemChanged;
        private void OnListItemChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (ListItemChanged != null) { this.ListItemChanged(this, e); }
        }
    }
