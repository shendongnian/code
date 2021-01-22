    private IList result;
    public IList Result
    {
        get
        {
            result = typeof(Priority).GetStrings();
            return result;
        }
    }
