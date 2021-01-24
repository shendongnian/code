    public ICollection<string> GetIssuingDatesOfUserBetweenDates(string userName, 
        DateTime startDate,
        DateTime endDate)
    {
        using (var dbContext = new MyDbContext(...))
        {
            return dbContext.Archives
                   .BetweenDates(startDate, endDate)
                   .ToIssuingDatesOfUser(userName)
                   .ToList();
        }
    }
