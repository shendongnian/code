    private string _a;
    private bool _manuallySettingA;
    public string A
    {
        get { return _a; }
        set
        {
            if (value != _a)
            {
                Set(ref _a, value);
                if(!_manuallySettingA)
                    SomeMethod(value);
            }
        }
    }
    public void ManuallySetA(string value)
    {
        _manuallySettingA = true;
        A = value;
        _manuallySettingA = false;
    }
