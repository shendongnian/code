    public static IEnumerable<Range> GetRanges(IEnumerable<DateTime> dates)
    {
        var start = dates.First();
        var end = dates.First();
        var prev = dates.First();
        var next = DateTime.Now;
            
        foreach(var d in dates.Skip(1))
        {
            next = d;
            var diff = next - prev;
            if (diff.TotalDays > 1)
            {
                yield return new Range { Start = start, End = end };
                start = d;   
            }
            prev = d;
            end = d;
        }
        yield return new Range { Start = start, End = end };
    }
