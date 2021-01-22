    public class Class1 : INotifyPropertyChanged
    {
        private string _ItemName;
        public string ItemName
        {
           get { return _ItemName; }
           set
           {
             _ItemName = value;
             NotifyPropertyChanged("ItemName");
           }
        }
        private void NotifyPropertyChanged(string name)
        {
          if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
