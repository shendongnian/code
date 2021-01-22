        public Status PersonStatus
        {
            get
            {
                return status;
            }
            set
            {
                if (value != status)
                {
                    status= value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("PersonStatus"));
                }
            }
        }
