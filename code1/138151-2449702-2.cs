    bool _isSettingAOrB;
    private int _a;
    public void SetA(int value)
    {
        SetInterdependentValues(() => _a = value, () => SetB(_a - 10));
    }
    
    private int _b;
    public void SetB(int value)
    {
        SetInterdependentValues(() => _b = value, () => SetA(_b + 10));
    }
    
    private void SetInterdependentValues(Action primary, Action secondary)
    {
        primary();
    
        if (_isSettingAOrB)
        {
            return;
        }
        _isSettingAOrB = true;
        try
        {
            secondary();
        }
        finally
        {
            _isSettingAOrB = false;
        }
    }
