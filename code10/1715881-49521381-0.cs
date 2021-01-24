    public class ChildClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
        public string ParentName {get;set;}
        private string _ChildName;
        public string ChildName
        {
            get { return _ChildName; }
            set { _ChildName = value; NotifyPropertyChanged("ChildName"); }
        }
    }
