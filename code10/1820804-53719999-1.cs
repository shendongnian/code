    public static IQueryable<Archive> BetweenDates(this IQueryable<Archive> archives,
        DateTime startDate,
        DateTime endDate)
    {
         return archives.Where(archive => startDate <= archive.IssuingDate
                                       && archive.IssuingDate <= endDate);
    }
    
