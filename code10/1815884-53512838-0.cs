    IList<Result> _Results;
    public IList<Result> Results
    {
        get
        {
            return _Results ?? new List<Result>();
        }
        set
        {
            _Results = value;
        }
    } 
