    var userTimes = from t in context.TrackedTimes
        group t by new 
        {
            t.User.UserName, 
            WeekNumber = context.WeekOfYear(t.TargetDate)
        } into ut
        select new 
        {
            UserName = ut.Key.UserName,
            WeekNumber = ut.Key.WeekNumber,
            Minutes = ut.Sum(t => t.Minutes)
        };
