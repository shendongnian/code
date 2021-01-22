    public string FirstName
    {
        get { return _firstName; }
        set
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged
                    (this, new PropertyChangedEventArgs("FirstName"));
            }
            _firstName = value;
        }
    }
