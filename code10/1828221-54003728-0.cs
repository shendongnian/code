    namespace myproject.Models
    {
      public class projectmodel : INotifyPropertyChanged
      {
        private ObservableCollection<string> city;
        private ObservableCollection<string> temperature;
        private ObservableCollection<string> state;
    
        public ObservableCollection<string> City
        {
          get { return city; }
          set
          {
            city = value;
            NotifyPropertyChanged("City");
          }
        }
    
        public ObservableCollection<string> Temperature
        {
          get { return temperature; }
          set
          {
            temperature = value;
            NotifyPropertyChanged("Temperature");
          }
        }
    
        public ObservableCollection<string> State
        {
          get { return state; }
          set
          {
            state = value;
            NotifyPropertyChanged("State");
          }
        }
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        #endregion
    
        #region Private Helpers
    
        private void NotifyPropertyChanged(string propertyName)
        {
          if (PropertyChanged != null)
          {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
        }
    
        #endregion
      }
    }
