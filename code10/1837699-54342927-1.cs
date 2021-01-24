    public abstract class TimesheetEntryEntity: INotifyPropertyChanged
    {
        public event EventHandler Changed;
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void OnChange()
        {
            EventHandler handler = Changed;
            handler?.Invoke(this, EventArgs.Empty);
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
                OnChange();
                //Do something with changed property
            }
        }
