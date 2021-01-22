    public decimal GetTotalReleasedFederalAmountByDate()
    {
        return ComputeFinancialSum( BeginDate, EndDate, 
                                    (x) => x.ReleasedFederalAmount );
    }
    public decimal GetTotalReleasedNonFederalAmountByDate()
    {
        return ComputeFinancialSum( BeginDate, EndDate, 
                                    (x) => x.ReleasedNonFederalAmount );
    }
    // other versions ....
