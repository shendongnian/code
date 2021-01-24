    [Aggregatable]
    [NotifyPropertyChanged]
    public class Page : INotifyPropertyChanged
    {
        //[Parent]
        [Reference]
        public Wizard Wizard { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }
        [SafeForDependencyAnalysis]
        public bool Enabled
        {
            get
            {
                if ( Depends.Guard )
                    Depends.On( Wizard.Pages );
                return Wizard.Pages
                    .TakeWhile( p => p != this )
                    .All( p => p.Valid );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        void OnPropertyChanged( string propertyName )
        {
            PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            if ( Wizard != null && propertyName != nameof( Enabled ) )
                NotifyPropertyChangedServices.SignalPropertyChanged( Wizard, nameof( Wizard.Pages ) );
        }
    }
