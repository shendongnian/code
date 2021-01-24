    IList<Result> _Results;
    public IList<Result> Results
    {
        get => _Results ?? (_Results = new List<Result>());
        
        set
        {
            _Results = value;
        }
    } 
