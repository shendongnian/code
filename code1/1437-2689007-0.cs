    public class BoundObject : INotifyPropertyChanged {
        private int _value;
        private string _text;
        public event PropertyChangedEventHandler PropertyChanged;
        public int Value {
            get {
                return _value;
            }
            set {
                if (_value != value) {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
        public string Text {
            get {
                return _text;
            }
            set {
                if (_text != value) {
                    _text = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        public void Init(){
            _text = "InitialValue";
            _value = 1;
            OnPropertyChanged(string.Empty);
        }
        public void Reset() {
            _text = "DefaultValue";
            _value = 0;
            OnPropertyChanged(string.Empty);
        }
        private void OnPropertyChanged(string propertyName) {
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
    }
