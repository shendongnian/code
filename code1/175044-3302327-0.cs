    public class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private YourIconType _Icon;
        public YourIconType Icon
        {
            get { return _Icon; }
            set
            {
                _Icon = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, 
                        new PropertyChangedEventArgs("Icon"));
            }
        }
    }
