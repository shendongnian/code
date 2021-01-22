    public partial class MyUserControl : UserControl, INotifyPropertyChanged
    {
      
      string _myProperty;
      public string MyProperty
      {
         get { return _myProperty; }
         set
         {
           _myProperty = value;
           NotifyPropertyChanged("MyProperty");
         }
      }
      private void NotifyPropertyChanged(string name)
      {
          if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(name);
      }
      public event PropertyChangedEventHandler PropertyChanged
    }
