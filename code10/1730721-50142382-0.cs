    private ObservableCollection<Character> _Characters;
    
    public ObservableCollection<Character> Characters
    {
        get { return _Characters; }
        set { Set(ref _Characters, value);}
    }
