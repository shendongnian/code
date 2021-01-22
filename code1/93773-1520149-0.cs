    public class Objective : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    FirePropertyChanged("Text");
                }
            }
        }
        private void FirePropertyChanged(string s)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
    }
