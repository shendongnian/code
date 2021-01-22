    public Decimal CalculateEarnings(Guid id)
    {
        var timeData = from tr in Context.TimeRecords
                       where tr.Id = id
                       select new EarningsCalculationContext
                       {
                           Salary = tr.Employee.Salary,
                           StepRates = from s in tr.Job.Steps
                                       select s.Rate,
                           TotalHours = tr.Stop – tr.Start
                       }.First();
        // Calculate has no knowledge of entity model
        return EarningsHelpers.Calculate(timeData); 
    }
