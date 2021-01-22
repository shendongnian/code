    public const string YearOneByIndexPropertyName = "YearOneByIndex";
    public int YearOneByIndex
    {
        get
        {
            return _yearOneByIndex;
        }
    
        set
        {
            if (_yearOneByIndex  == value)
            {
                return;
            }
    
            _yearOneByIndex = value;
            _yearOneByPercentage = 0
    
            RaisePropertyChanged(YearOneByIndexPropertyName);
            RaisePropertyChanged(YearOneByPercentagePropertyName);
        }
    }
    
    public const string YearOneByPercentagePropertyName = "YearOneByPercentage";
    public int YearOneByPercentage
    {
        get
        {
            return _yearOneByPercentage;
        }
    
        set
        {
            if (_yearOneByPercentage == value)
            {
                return;
            }
    
            _yearOneByPercentage = value;
            _yearOneByIndex = 0;
    
            RaisePropertyChanged(YearOneByIndexPropertyName);
            RaisePropertyChanged(YearOneByPercentagePropertyName);
        }
    }
