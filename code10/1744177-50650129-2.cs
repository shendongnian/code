    private ObservableCollection<DataPoint> _BestFitness;
    public ObservableCollection<DataPoint> BestFintess
    {
        get
        {
            return _BestFitness;
        }
        private set
        {
            _BestFitness = value;
            RaisePropertyChangedEvent(nameof(BestFintess));
        }
    }
