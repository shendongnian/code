    using System.ComponentModel;
    namespace MyWebGrocer.Uma.UI
    {
      public class BoundClass : INotifyPropertyChanged
      {
        private string _Name;
        private int _Age;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name
        {
          get
          {
            return _Name;
          }
          set
          {
            _Name = value;
            OnPropertyChanged("Name");
          }
        }
        public int Age
        {
          get
          {
            return _Age;
          }
          set
          {
            _Age = value;
            OnPropertyChanged("Age");
          }
        }
        protected void OnPropertyChanged(string propertyName)
        {
          var propertyChanged = PropertyChanged;
          if (propertyChanged != null)
          {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
        }
      }
    }
