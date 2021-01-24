    private int _currentNumber;
    public int CurrentNumber
    {
        get
        {
            return _currentNumber;
        }
        set
        {
            _currentNumber = value;
            OnPropertyChanged("CurrentNumber");
        }
    }
    
    public void CountUp()
    {
        // current = Nummer.Count + 1;
        CurrentNumber += Current + 1;
        Nummer.Add(new NumberViewModel { Num = CurrentNumber });
    }
    public void Multiply(int multiplyParameter)
    {
        CurrentNumber = _mulmultiplyParametertiply * multiplyParameter;
        Nummer.Add(new NumberViewModel { Num = CurrentNumber});
    }
