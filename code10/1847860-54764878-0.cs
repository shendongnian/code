        static DateTime RoundTime(DateTime dt, int roundInterval)
        {
            TimeSpan ts = dt.TimeOfDay;
            int modInterval = ts.Minutes % roundInterval;
            if (modInterval > 5)
            {
                return dt.Add(new TimeSpan(0, roundInterval - modInterval, 0));
                
            } else
            {
                return dt.Subtract(new TimeSpan(0, modInterval, 0));
            }
        }
