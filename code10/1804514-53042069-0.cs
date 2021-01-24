    protected void sample()
    {
        var now = DateTime.Now;
        var sql = GetSql(now.DayOfWeek, now.Hour);
        // execute sql
    }
    protected string GetSql(DayOfWeek dayofweek, int hour)
    {
        // generate sql, using "(int)dayofweek" if needed
    }
