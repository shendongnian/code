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
        ...
    }
    public bool CanCountUp()
    {
        return Current <= 512;  
    }
