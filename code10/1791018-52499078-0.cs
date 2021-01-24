    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _monthDaysList;
        public ObservableCollection<string> MonthDaysList
        {
            get { return _monthDaysList; }
            internal set { _monthDaysList = value; OnPropertyChanged(); }
        }
        private string _selectedMonthDay;
        public string SelectedMonthDay
        {
            get { return _selectedMonthDay; }
            internal set { _selectedMonthDay = value; OnPropertyChanged(); }
        }
        public void GetMonths()
        {
            MonthDaysList = new ObservableCollection<string>();
            if (MyConceptItems != null && MyConceptItems.Any())
            {
                foreach (var item in MyConceptItems)
                {
                    MonthDaysList.Add(item.DateColumn);
                }
                SelectedMonthDay = MonthDaysList[0];
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
