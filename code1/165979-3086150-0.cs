    public int getAverageTime()
        {
            return (from EventTime in db.EventTimes
                    where EventTime.EventTimesID > 0
                    select (SqlMethods.DateDiffMinute(EventTime.TimeStart, EventTime.TimeEnd)).Average();
        }
