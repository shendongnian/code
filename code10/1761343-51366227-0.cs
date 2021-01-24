    public class DataManager : INotifyPropertyChanged
    {
        // Singleton
    
    
       private UserModel _loggedUser;
       public UserModel LoggedUser
       { 
          get
          {
            return _loggedUser;
          }
        set
        {
            _loggedUser = value;
            OnPropertyChanged("LoggedUser");
        }
    }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
    
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
