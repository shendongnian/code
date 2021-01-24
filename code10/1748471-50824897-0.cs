    public IEnumerable<Property> GetFeaturedProperties()
    {
        var DateTimeNow = DateTime.Now;
        var midnightToday = DateTimeNow.AddHours(-DateTimeNow.Hour)
                                       .AddMinutes(-DateTimeNow.Minute)
                                       .AddSeconds(-DateTimeNow.Second-1);
        return _db.Properties
            .Include(p => p.GeoInfo) // assuming you want to return this data
            .Where(p => p.FeaturedUntil.Any(p => p.FeaturedDate >= midnightToday))
            .ToList();
    }
