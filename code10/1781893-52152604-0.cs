    public class ViewModel : INotifyPropertyChanged
    {
        private int _a;
        public int A
        {
            get { return _a; }
            set { _a = value; NotifyPropertyChanged(nameof(C)); }
        }
        private int _b;
        public int B
        {
            get { return _b; }
            set { _b = value; NotifyPropertyChanged(nameof(C)); }
        }
        public int C => _a + _b;
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "") =>
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
