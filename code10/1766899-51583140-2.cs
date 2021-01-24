    private ObservableCollection<Round> _rounds;
    public ObservableCollection<Round> Rounds
    {
        get { return _rounds; }
        set
        {
            _rounds = value;
            OnPropertyChanged("Rounds");
        }
    }
