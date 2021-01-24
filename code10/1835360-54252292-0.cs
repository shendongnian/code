    public ObservableCollection<KeyStroke> keyList = new ObservableCollection<KeyStroke>();
    public class KeyStroke : INotifyPropertyChanged
    {
        // KeyStroke class storing data about each key and how many types it received
        private int id;
        private int numPress;
        public KeyStroke(int id, int numPress)
        {
            Id = id;
            NumPress = numPress;
        }
        public int Id
        {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public int NumPress
        {
            get { return this.numPress; }
            set
            {
                this.numPress = value;
                NotifyPropertyChanged("NumPress");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged; //This handle the propertyChanged
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //This is the WPF code for the DataGrid but you can replace it by whatever you need
        }
    }
