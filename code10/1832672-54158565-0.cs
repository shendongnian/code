        private ObservableCollection<DutyDay> tour;
        public ObservableCollection<DutyDay> Tour
        {
            get
            {
                return tour;
            }
            set
            {
                tour = value;
                OnPropertyChanged(nameof(Tour));
            };
        }
