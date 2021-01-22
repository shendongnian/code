     public class MyClass : INotfyPropertyChanged
     {
        string _name;
        public string Name
        {
          get {return _name; }
          set { _name = value; NotifyPropertyChanged("Name"); }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
           if (PropertyChanged != null)
             PropertyChanged(this, new PropertyChangedEventArgs(propertyName))
        }
        public event PropertyChangedEventHandler PropertyChanged
     }
