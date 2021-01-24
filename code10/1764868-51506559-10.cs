    private int Period(DateTime date)
    {
        return (int)Math.Ceiling(date.Month / 2.0);
        // or...
        // return (date.Month + 1) / 2;
        // but I prefer the Ceiling option since it is more obvious what is happening
    }
    
