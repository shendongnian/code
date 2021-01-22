     public class Device : INotifyPropertyChanged
     {
         private string _StatusName;
         public string StatusName
         {
             get { return _StatusName; }
             set
             {
                 _StatusName = value;
                 NotifyPropertyChanged("StatusName");
             }
         }
         private void NotifyPropertyChanged(string name)
         {
              if (PropertyChanged != null)
                  PropertyChanged(this, new PropertyChangedEventArgs(name));
         }
         #region INotifyPropertyChanged Members
         public event PropertyChangedEventHandler PropertyChanged;
         #endregion       
     }
