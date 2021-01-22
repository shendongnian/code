    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            if (value != _name) {
                _name = value;
                OnPropertyChanged(); // Call without the optional parameter!
            }
        }
    }
