    public class CalendarCellsViewModel : INotifyPropertyChanged
    {
        private string _dateTitle;
        private ObservableCollection<CalendarDayData> _days;
        private CalendarDayData _selectedDay;
        public string DateTitle
        {
            get { return _dateTitle; }
            set
            {
                _dateTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateTitle)));
            }
        }
        public ObservableCollection<CalendarDayData> Days
        {
            get { return _days; }
            set
            {
                _days = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Days)));
            }
        }
        public CalendarDayData SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                _selectedDay = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedDay)));
            }
        }
        public CalendarCellsViewModel()
        {
            DateTitle = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Today.Month)} {DateTime.Today.Year}";
            Days = new ObservableCollection<CalendarDayData>();
            for (int i = 1; i <= 31; i++)
            {
                var day = new CalendarDayData { DayNumber = i, Message = "Test" };
                if (i == DateTime.Today.Day)
                    SelectedDay = day;
                Days.Add(day);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
