            public List<DateTime> GetOccurrencesInWeeksInterval(DateTime start, DateTime end)
        {
            var ret = new List<DateTime>();
            DateTime? lastDate = null;
            int weekInterval = _rptConfig.Interval;
            CronExpression expression = CronExpression.Parse(this.GetCronExpression()); // this would return something like "0 9 * * 1,3,5"
            var dates = expression.GetOccurrences(start, end).ToList();
            if (weekInterval == 1) {
                return dates;
            }
            if (dates.Any())
            {
                foreach (var date in dates)
                {
                    if (lastDate == null)
                    {
                        ret.Add(date);
                        lastDate = date;
                    }
                    else
                    {
                        var weekDiff = HelperFunctions.GetWeekDiff(lastDate.Value, date);
                        if (weekDiff == 0)
                        {
                            ret.Add(date);
                        }
                        else if (weekDiff > 0 && (weekDiff % weekInterval) == 0)
                        {
                            ret.Add(date);
                        }
                    }
                }
            }
            return ret;
        }
