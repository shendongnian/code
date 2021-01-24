    private ObservableCollection<Currency> _coins = new ObservableCollection<Currency>();
    public ObservableCollection<CryptoCurrency> Coins
    {
        get
        {
            return _coins;
        }
        set
        {
            SetObservableProperty(ref _coins, value);
        }
    }
    private Currency selectedCoin;
    public Currency SelectedCoin
    {
        get { return selectedCoin; }
        set
        {
            if (selectedCoin != value)
            {
                selectedCoin = value;
                RaisePropertyChanged(() => this.SelectedCoin);
            }
        }
    }
