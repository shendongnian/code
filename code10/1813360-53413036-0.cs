    private string _phonePrefix;
    public string PhonePrefix
    {
        get
        {
            return _phonePrefix;
        }
        set
        {
            if (!String.Equals(_phonePrefix, value))
            {
                _phonePrefix = value;
                OnPropertyChanged("PhonePrefix");
            }
        }
    }
