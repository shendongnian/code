    class MainViewModel : BindableBase
    {
        private ObservableCollection<WeekDays> _weekDays;
        public ObservableCollection<WeekDays> WeekDays
        {
            get
            {
                return _weekDays;
            }
            set
            {
                SetProperty(ref _weekDays, value);
            }
        }
        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                SetProperty(ref _selectedIndex, value);
            }
        }
        private WeekDays _selectedWeekDay;
        public WeekDays SelectedWeekDay
        {
            get
            {
                return _selectedWeekDay;
            }
            set
            {
                SetProperty(ref _selectedWeekDay, value);
            }
        }
        private void FillWeekDays()
        {
            using (NLTrader01Entities nlt = new NLTrader01Entities())
            {
                var q = (from a in nlt.WeekDays select a).ToList();
                WeekDays = new ObservableCollection<WeekDays>(q);
            }
        }
        public MainViewModel()
        {
            FillWeekDays();
            SelectedIndex = 4;       
        }
    }
