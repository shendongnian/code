        public class MyViewModel
        {
           public ObservableCollection<MyObject> MyData { get; set; }
        }
    
        public class MyObject : INotifyPropertyChanged
        {
           public MyObject()
           {
           }
        
           private string _status;
           public string Status
           {
             get { return _status; }
             set
             {
               if (_status != value)
               {
                 _status = value;
                 RaisePropertyChanged("Status"); // Pass the name of the changed Property here
               }
             }
           }
    
           public event PropertyChangedEventHandler PropertyChanged;
    
           private void RaisePropertyChanged(string propertyName)
           {
              PropertyChangedEventHandler handler = this.PropertyChanged;
              if (handler != null)
              {
                  var e = new PropertyChangedEventArgs(propertyName);
                  handler(this, e);
              }
           }
        }
