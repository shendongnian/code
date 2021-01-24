    class SomeViewModel : ViewModelBase
    {
        void SomeMethod ( )
        {
            Obs.Add ( "item" );
            Obs.Clear ( );
        }
        public ObservableCollection<string> Obs { get; } 
         = new ObservableCollection<string> ( );
        public ObservableCollection<string> Obs2 { get; }
         = new ObservableCollection<string> ( );
    }
    class SomeParentViewModel : ViewModelBase
    {
        public SomeParentViewModel ( )
        {
             Child.Obs.CollectionChanged += ( sender, e ) => { /* Handles collection changed logic */ };
            Child.Obs2.CollectionChanged += ( sender, e ) => { /* Handles collection changed logic */ };
        }
        public SomeViewModel Child { get; }
         = new SomeViewModel ( );
    }
