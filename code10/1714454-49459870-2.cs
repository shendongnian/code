    class SomeViewModel : ViewModelBase, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public SomeViewModel ( )
        {
            Obs.CollectionChanged += CollectionChanged;
        }
        public ObservableCollection<string> Obs { get; } 
         = new ObservableCollection<string> ( );
    }
