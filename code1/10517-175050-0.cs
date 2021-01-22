    using System.ComponentModel;
    
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        string _firstname;
        public string FirstName {
            get {
                return _firstname;
            }
            set {
                _firstname = value;
                onPropertyChanged( "FirstName" );
            }
        }
    
        string _lastname;
        public string LastName {
            get {
                return _lastname;
            }
            set {
                _lastname = value;
                onPropertyChanged( "LastName" );
            }
        }
        
        void onPropertyChanged( string propertyName ) {
            PropertyChangedEventHandler handler = PropertyChanged;
            
            if ( handler != null ) {
                handler( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
    }
