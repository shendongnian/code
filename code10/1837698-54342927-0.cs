    public abstract class TimesheetEntryEntity: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private DateTime date;
        public DateTime Date
        {
            get => date;
            set
            {
                if (date == value)
                {
                    return;
                }
                //Do something with unchanged property
                date = value;
                RaisePropertyChanged();
                //Do something with changed property
            }
        }
