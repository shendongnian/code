    private string _numberPagesToPrint;
    public string NumberPagesToPrint
    {
        get { return _numberPagesToPrint; }
        set
        {
            if (_numberPagesToPrint == value)
            {
                return;
            }
            _numberPagesToPrint = value;
            OnPropertyChanged("NumberPagesToPrint");
        }
    }
