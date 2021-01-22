    class ViewModel : INotifyPropertyChanged
    {
        private string text = string.Empty;
        public string Text
        {
            get { return this.text; }
            set
            {
                this.text = value;
                this.OnPropertyChanged("Text");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            var eh = this.PropertyChanged;
            if(null != eh)
            {
                eh(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
