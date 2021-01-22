    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            this.data.Add(1, "One");
            this.data.Add(2, "Two");
            this.data.Add(3, "Three");
        }
    
        Dictionary<int, string> data = new Dictionary<int, string>();
        public IDictionary<int, string> Data
        {
            get { return this.data; }
        }
        private KeyValuePair<int, string>? selectedKey = null;
        public KeyValuePair<int, string>? SelectedKey
        {
            get { return this.selectedKey; }
            set
            {
                this.selectedKey = value;
                this.OnPropertyChanged("SelectedKey");
                this.OnPropertyChanged("SelectedValue");
            }
        }
        
        public string SelectedValue
        {
            get
            {
                if(null == this.SelectedKey)
                {
                    return string.Empty;
                }
                
                return this.data[this.SelectedKey.Value.Key];
            }
            set
            {
                this.data[this.SelectedKey.Value.Key] = value;
                this.OnPropertyChanged("SelectedValue");
            }
        }
        
        public event PropertyChangedEventHandler  PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            var eh = this.PropertyChanged;
            if(null != eh)
            {
                eh(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
