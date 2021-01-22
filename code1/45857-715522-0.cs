       [System.ComponentModel.Bindable(true)] 
       public string MyName
       {
           get { return _myName; }
           set
           {
              if( _myName != value )
              {
                  _myName = value;
                  OnPropertyChanged("MyName");
              }
           }
       }
