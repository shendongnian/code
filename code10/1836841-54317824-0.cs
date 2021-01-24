    Func<Statistic, DateTime> expMin = i => Sql.Min(i.DateTimeCest);
    ...
    private static DateTime? GetDateFromStatistics(IDbConnection db, 
                                                     Func<Statistic, DateTime> exp)
    {
       return db.Single<DateTime?>(db.From<Statistic>().Select(exp));
    }
    ...
    GetDateFromStatistics(db, expMin);
