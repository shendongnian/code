    DateTime firstDay = GetFirstDayOfFirstWeekOfYear();
    var userTimes = 
        from t in context.TrackedTimes.Where(myPredicateHere).AsEnumerable()
        group t by new {t.User.UserName, WeekNumber = (t.TargetDate - firstDay).Days / 7} into ut
        select new
        {
            UserName = ut.Key.UserName,
            WeekNumber = ut.Key.WeekNumber,
            Minutes = ut.Sum(t => t.Minutes)
        };
