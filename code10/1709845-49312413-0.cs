    public class DriverStatusViewModel : INotifyPropertyChanged
        {
            List<DriverStatus> statusList;
            public List<DriverStatus> StatusList
            {
                get { return statusList; }
                set
                {
                    if (statusList != value)
                    {
                        statusList = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string Title { get; set; }
            DriverStatus selectedStatus;
            public DriverStatus SelectedStatus
            {
                get { return selectedStatus; }
                set
                {
                    if (selectedStatus != value)
                    {
                        selectedStatus = value;
                        OnPropertyChanged();
                    }
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
