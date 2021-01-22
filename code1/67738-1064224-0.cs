    DateTime firstDay = GetFirstDayOfFirstWeekOfYear();
    var userTimes = from t in context.TrackedTimes
                    group t by new {t.User.UserName, t.TargetDate.WeekNumber( firstDay)} into ut
                    select new
                    {
                        UserName = ut.Key.UserName,
                        WeekNumber = ut.Key.WeekNumber,
                        Minutes = ut.Sum(t => t.Minutes)
                    };
