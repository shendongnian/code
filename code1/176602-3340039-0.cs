    public const string YearOneByIndexPropertyName = "YearOneByIndex";
    public int YearOneByIndex
    {
        get
        {
            return _YearOneByIndex;
        }
    
        set
        {
            if (_YearOneByIndex  == value)
            {
                return;
            }
    
            _YearOneByIndex = value;
            _YearOneByPercentage = 0
    
            RaisePropertyChanged(YearOneByIndexPropertyName);
            RaisePropertyChanged(YearOneByPercentagePropertyName);
        }
    }
    
    public const string YearOneByPercentagePropertyName = "YearOneByPercentage";
    public int YearOneByPercentage
    {
        get
        {
            return _YearOneByPercentage;
        }
    
        set
        {
            if (_YearOneByPercentage == value)
            {
                return;
            }
    
            _YearOneByPercentage = value;
            _YearOneByIndex = 0;
            if (!_currentVehicleMembershipChange.Usable)
                _currentVehicleMembershipChange.Percentage = 0;
    
            RaisePropertyChanged(YearOneByIndexPropertyName);
            RaisePropertyChanged(YearOneByPercentagePropertyName);
        }
    }
