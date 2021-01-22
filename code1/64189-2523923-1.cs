        public string Text
        {
            get { return text; }
            set { 
                text = value;
                NotifyPropertyChanged("Text");
                }
        }
