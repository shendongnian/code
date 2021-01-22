    void getTimes()
    {
        YourEntities context = new YourEntities();
        DateTime firstDay = GetFirstDayOfFirstWeekOfYear();
        var weeks = context.CreateQuery<System.Data.Common.DbDataRecord>(
            "SELECT t.User.UserName, SqlServer.DateDiff('DAY', @beginDate, t.TargetDate)/7 AS WeekNumber " +
            "FROM YourEntities.TrackedTimes AS t " +
            "GROUP BY SqlServer.DateDiff('DAY', @beginDate, t.TargetDate)/7, t.User.UserName", new System.Data.Objects.ObjectParameter("beginDate", firstDay));
        List<customTimes> times = new List<customTimes>();
        foreach (System.Data.Common.DbDataRecord rec in weeks)
        {
            customTimes time = new customTimes()
            {
                UserName = rec.GetString(0),
                WeekNumber = rec.GetInt32(1)
            };
            times.Add(time);
        }
    }
    class customTimes
    {
        public string UserName{ get; set; }
        public int WeekNumber { get; set; }
    }
