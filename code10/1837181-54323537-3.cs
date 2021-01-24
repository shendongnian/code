    public class Setting : INotifyPropertyChanged
    {
        private double _itemWidth = 200;
        public double ItemWidth
        {
            get { return _itemWidth; }
            set { _itemWidth = value; OnPropertyChanged(); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
