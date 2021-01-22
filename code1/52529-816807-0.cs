        public class Narudzba : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propName));
            }
        }
        string _picturesource;
        public string Picture
        {
            get { return _picturesource; }
            set 
            { 
                _picturesource = value;
                Notify("Picture");
            }
        }
        public Narudzba(string picturesource)
        {
            _picturesource = picturesource;
        }
      }
    }
