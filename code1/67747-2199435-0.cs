    var userTimes = from t in context.TrackedTimes
                    group t by new {t.User.UserName, Year =  t.TargetDate.Year, WeekNumber = t.TargetDate.DayOfYear/7} into ut
                    select new
                    {
                        UserName = ut.Key.UserName,
                        WeekNumber = ut.Key.WeekNumber,
                        Minutes = ut.Sum(t => t.Minutes)
                    };
