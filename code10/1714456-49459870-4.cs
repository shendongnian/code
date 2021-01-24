    class SomeViewModel : ViewModelBase, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public SomeViewModel ( )
        {
            Obs.CollectionChanged += (sender, e) => CollectionChanged?.Invoke ( this, e ); // *edit*
        }
        public ObservableCollection<string> Obs { get; } 
         = new ObservableCollection<string> ( );
    }
