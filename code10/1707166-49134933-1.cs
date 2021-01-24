     private Repository _repo;
        public Repository Repo
        {
            get { return _repo; }
            set
            {
                _repo = value;
                OnPropertyChanged("Repo");
                com.RaiseCanExecuteChanged();
            }
        }
