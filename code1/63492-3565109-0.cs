        public enum Properties
        {
            NetworkFileName,
            DatasetFileName,
            LearningWatch
        }
        private string network_filename;
        public string NetworkFileName 
        {
            get { return network_filename; }
            private set 
            {
                if (network_filename != value)
                {
                    network_filename = value;
                    OnPropertyChanged(Properties.NetworkFileName.ToString());
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public void OnChange(Properties prop, Action<object, PropertyChangedEventArgs> action)
        {
            PropertyChanged += new PropertyChangedEventHandler((obj, args) => { if (args.PropertyName == prop.ToString()) action(obj, args); });
        }
