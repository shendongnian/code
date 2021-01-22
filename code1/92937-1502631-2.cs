    public class TheClass : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
    
       private MyEnum _myField;
    
       public MyEnum MyPropertyName
       {
          get { return _myField; }
          set 
          {
             if( _myField != value )
             {
                 _myField = value;
                 if( PropertyChanged != null )
                      PropertyChanged ("MyPropertyName");
             }
          }
       }
    }
