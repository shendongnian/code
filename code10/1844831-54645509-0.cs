    private static DateTime FineNearestDateTime(IEnumerable<DateTime> dates, DateTime dateTime)
    {
        var difference = double.MaxValue;
        var nearestDate = DateTime.MinValue;
        foreach (var item in dates)
        {
            if (item == dateTime)
                return dateTime;
            var newDiff = Math.Abs((dateTime - item).TotalMilliseconds);
            if (newDiff < difference)
            {
                nearestDate = dateTime;
                difference = newDiff;
            }
        }
        return nearestDate;
    }
