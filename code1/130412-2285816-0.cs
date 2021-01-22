    public class ViewModel  : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool _ButtonAChecked = true;
        public bool ButtonAChecked
        {
            get { return _ButtonAChecked; }
            set 
            { 
                _ButtonAChecked = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ButtonAChecked"));
                if (value) ButtonBChecked = false;
            }
        }
        protected bool _ButtonBChecked;
        public bool ButtonBChecked
        {
            get { return _ButtonBChecked; }
            set 
            { 
                _ButtonBChecked = value; 
                PropertyChanged(this, new PropertyChangedEventArgs("ButtonBChecked"));
                if (value) ButtonAChecked = false;
            }
        }
    }
