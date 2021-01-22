    public Decimal CalculateEarnings(Guid id)
    {
        var timeRecord = (from tr in Context.TimeRecords
                          .Include(“Employee.Person”)
                          .Include(“Job.Steps”)
                          .Include(“TheWorld.And.ItsDog”)
                          where tr.Id = id
                          select tr).First();
        // Calculate has deep knowledge of entity model
        return EarningsHelpers.Calculate(timeRecord); 
    }
