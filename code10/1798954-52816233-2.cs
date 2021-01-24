    public CounterViewModel()
    {
        CountUpCommand = new Command(CountUp, CanCountUp);
    }
    public int Current
    {
        get
        {
            return _currentNumber;
        }
        set
        {
            _currentNumber = value;
            OnPropertyChanged();
            CountUpCommand.ChangeCanExecute();
        }
    }
    public void CountUp()
    {
        Current++; //will result in calling CanCountUp and updating button status
        Nummer.Add(new NumberViewModel { Num = Current });
    }
    public bool CanCountUp()
    {
        return Current <= 512;  
    }
