    public abstract class ObservableObject : INotifyPropertyChanged
    {
    
        protected ObservableObject( )
        {
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged( PropertyChangedEventArgs e )
        {
            var handler = PropertyChanged;
            if ( handler != null ) {
                handler( this, e );
            }
        }
    
        protected void OnPropertyChanged( string propertyName )
        {
            OnPropertyChanged( new PropertyChangedEventArgs( propertyName ) );
        }
    
    }
