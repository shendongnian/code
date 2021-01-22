    private List<Date> _dates = new List<Date>();
    private ReadOnlyCollection<Date> _readOnlyDates =
        new ReadOnlyCollection<Date>(_dates);
    public ReadOnlyCollection<Date> Dates
    {
        get { return _readOnlyDates; }
    }
