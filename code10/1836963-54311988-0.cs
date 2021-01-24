    private ObservableCollection<ClassB> _classBs;
        public ObservableCollection<ClassB> ClassBs
        {
            get { return _classBs; }
            set
            {
                _classBs = value;
                OnPropertyChanged();
                OnPropertyChanged("Status");
            }
        }
