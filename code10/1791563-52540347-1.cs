    public  class View : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(PropertyName));
        }
    
        private bool _isVisible;
        public bool IsVisible
        {
            get
            {
                return this._isVisible;
            }
            set
            {
                this._isVisible = value;
                this.OnPropertyChanged(IsVisible) <--- The Magic! 
            }
        }
    }
