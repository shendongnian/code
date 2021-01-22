    public class DataSourceClass : INotifyPropertyChanged
    { 
        private string _data;
    
        public string Data
        {
            get
            {
                return _data;
            }  
            set
            {
                if( _data != value )
                {
                    _data = value;
                    OnPropertyChanged( "data" );
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged( string propertyName )
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if( handler != null )
            {
                handler( new PropertyChangedEventArgs( propertyName ) );
            }
        }
    } 
