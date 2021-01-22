    class User : INotifyPropertyChanged {
       public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void OnPropertyChanged(string propertyName) {
          PropertyChangedEventHandler handler = PropertyChanged;
          if(handler!=null) handler(this, new PropertyChangdEventArgs(propertyName));
       }
       private string userId;
       public string UserId {
           get {return userId;}
           set {
               if(userId != value) {
                  userId = value;
                  OnPropertyChanged("UserId");
               }
           }
       }
    }
