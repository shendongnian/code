      public class DefaultModel : INotifyPropertyChanged
    {
        private string userName = string.Empty;
        private string description = string.Empty;
        private string sign = string.Empty;
        private TimeSpan arrival = TimeSpan.Zero;
        private TimeSpan depart = TimeSpan.Zero;
        public string Name
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public TimeSpan Arrival
        {
            get
            {
                return arrival;
            }
            set
            {
                arrival = value;
                RaisePropertyChanged(nameof(Arrival));
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }
        public TimeSpan Depart
        {
            get
            {
                return depart;
            }
            set
            {
                depart = value;
                RaisePropertyChanged(nameof(Depart));
            }
        }
        public string Sign
        {
            get
            {
                return sign;
            }
            set
            {
                sign = value;
                RaisePropertyChanged(nameof(Sign));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
