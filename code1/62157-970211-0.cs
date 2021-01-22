    List<TimeSpan> list = new List<TimeSpan>
        {
            new TimeSpan(1),
            new TimeSpan(2),
            new TimeSpan(3)
        };
    TimeSpan total = list.Aggregate(TimeSpan.Zero, (sum, value) => sum.Add(value));
    Debug.Assert(total.Ticks == 6);
