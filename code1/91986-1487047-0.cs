    public IQueryable<Dinner> GetAllUserDinnersAndRSVPs(string userId)
    {
        DataLoadOptions options = new DataLoadOptions();
        options.LoadWith<Dinner>(d => d.RSVPs); //whatever property has the RSVPS
        db.LoadOptions = options;
        return from dinner in db.Dinner
               where dinner.userId == userId
               select dinner;
    }
