    public int GetValue(DateTime date)
    {
        
        var result = Values.Single(g => g.date == date) ?? GetValueFor(date);
        lock (Values)
        {
            if (!Values.Contains(result)) Values.Add(result);
        }
        return result.value;
    }
    private PrecalculateValue GetValueFor(DateTime date)
    {
        //logic
        return new PrecalculateValue() ;
    }
