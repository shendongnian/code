    private Comparators _MySelectedItem;
        public Comparators MySelectedItem
        {
            get { return _MySelectedItem; }
            set
            {
                _MySelectedItem = value;
                OnPropertyChanged("MySelectedItem");
            }
        }
