    using System.ComponentModel;
    
    class Person : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        string _firstname;
        public string FirstName {
            get {
                return _firstname;
            }
            set {
                _firstname = value;
                onPropertyChanged( "FirstName", "FullName" );
            }
        }
        string _lastname;
        public string LastName {
            get {
                return _lastname;
            }
            set {
                _lastname = value;
                onPropertyChanged( "LastName", "FullName" );
            }
        }
        public string FullName {
            get {
                return _firstname + " " + _lastname;
            }
        }
        void onPropertyChanged( params string[] propertyNames ) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if ( handler != null ) {
                foreach ( var pn in propertyNames ) {
                    handler( this, new PropertyChangedEventArgs( pn ) );
                }
            }
        }
    }
