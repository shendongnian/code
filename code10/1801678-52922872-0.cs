        public class BindableValue<T> : INotifyPropertyChanged
        {
            private T _value;
            public T Value
            {
                get { return _value; }
                set {
                      _value = value;
                      OnPropertyChanged(nameof(Value));
                   }
            }
            // INotifyPropertyChanged implementation 
        }
        private ObservableCollection<BindableValue<string>> _msg;
        public ObservableCollection<BindableValue<string>> Msg
        {
            get { return _msg; }
            set { _msg= value;
                  OnPropertyChanged(nameof(Msg));
                }
        }
