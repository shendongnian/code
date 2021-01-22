    private List<Date> _dates = new List<Date>();
    public ReadOnlyCollection Dates
    {
        get { return new ReadOnlyCollection(_dates); }
    }
