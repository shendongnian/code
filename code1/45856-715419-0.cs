    public class MyClass : INotifyPropertyChanged
    {
       private string _myName;
    
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
     
       public event PropertyChangedEventHandler PropertyChanged;
 
       private void OnPropertyChanged(string propertyName)
       {
           if( PropertyChanged != null )
               PropertyChanged( this , new PropertyChangedEventArgs(propertyName) );
       }       
    }
