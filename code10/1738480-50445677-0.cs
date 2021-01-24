    public static IEnumerable<TimeSpan> Intervals(TimeSpan inclusiveStart, TimeSpan exclusiveEnd, TimeSpan increment)
    {
        for (var time = inclusiveStart; time < exclusiveEnd; time += increment)
            yield return time;
    }
