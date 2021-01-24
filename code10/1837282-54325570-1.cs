    public static Loan fromCVS(string csvLine)
    {
        // TODO: exception if csvLine null or empty
        var splitWithoutQuotes = csvLine.SplitAndRemoveQuotes()
            .Skip(2)        // we don't need the first two values
            .Take(5)        // we only need the next five values
            .ToList();
        // TODO: exception if result not 5 items
        
        return new Loan
        {
            employeNames = splitWithoutQuotes[0],
            ...
            amount = Double.Parse(values[4]);
            ...
        };
    }
        
