    private static DateTime? GetDateFromStatistics(IDbConnection db, 
                                                   Expression<Func<Statistic, DateTime>> exp)
    {
       return db.Single<DateTime?>(db.From<Statistic>()
                                     .Select(exp));
    }
