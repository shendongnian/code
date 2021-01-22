    class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        private string firstName;
        private string lastName;
    
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }
    
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }
        public string Error
        {
            get { throw new System.NotImplementedException(); }
        }
    
        public string this[string columnName]
        {
            get
            {
                string message = null;
                if (columnName == "FirstName" && string.IsNullOrEmpty(FirstName))
                {
                    message = "Please enter FirstName";
                }
                if (columnName == "LastName" && string.IsNullOrEmpty(LastName))
                {
                    message = "Please enter LastName";
                }
                return message;
            }
        }
    }
