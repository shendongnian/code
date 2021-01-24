    partial class Window1 : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Window1()
        {
            DataContext = this;
        }
        private string _name2;
        public string Name2
        {
            get { return _name2; }
            set
            {
                if (value != _name2)
                {
                    _name2 = value;
                    OnPropertyChanged("Name2");
                }
            }
        }
    }
