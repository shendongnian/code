    public static bool IsOverLapping(ConfigureViewModel vm, int numberOfOverlaps)
    {
        var ranges = vm.Periods.Select(q => new TimeRange(q.StartTime, q.EndTime));
        TimePeriodCollection periodCollection = new TimePeriodCollection(ranges);
        TimePeriodIntersector<TimeRange> intersector = new TimePeriodIntersector<TimeRange>();
        return intersector.IntersectPeriods(periodCollection).Count > numberOfOverlaps;
    }
