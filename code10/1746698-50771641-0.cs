    public class MainViewModel:INotifyPropertyChanged
    {
        private string _Name;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
        public MainViewModel()
        {
            this.Name = "Hello UWP!";
        }
        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
