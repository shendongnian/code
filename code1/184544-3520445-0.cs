    private double _currentProgress;
    public double CurrentProgress
    {
        get { return _currentProgress; }
        private set
        {
            _currentProgress = value;
            OnPropertyChanged("CurrentProgress");
        }
    }
