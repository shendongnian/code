    public class MyProperty : INotifyPropertyChanged {
      private string _value;
      public string Value { get { return _value; } set { _value = value; OnPropertyChanged("Value"); } }
      public event PropertyChangedEventHandler PropertyChanged;
      protected void OnPropertyChanged(string name) {
        PropertyChangedEventHandler handler = PropertyChanged;
        if(handler != null) {
          handler(this, new PropertyChangedEventArgs(name));
        }
      }
    }
