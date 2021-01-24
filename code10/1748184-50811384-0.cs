    public class Sample : INotifyPropertyChanged
    {
        private string _str;
        public string Str
        {
            get { return _str; }
            set
            {
                _str = value;
                NotifyPropertyChanged(nameof(Str));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
