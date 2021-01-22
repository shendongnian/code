    private DateTime _start;
    private TimeSpan _maxTime = new TimeSpan(0, 0, 400);
    public void TimedSearch()
    {
        _start = DateTime.Now;
        DoSearch();
    }
    public void DoSearch()
    {
        while (notFound)
        {
            if (DateTime.Now - _start > _maxTime)
                return;
            // search code
        }
    }
    
