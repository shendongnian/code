    /// <summary>
    /// Gets the duration of the set union of the specified intervals.
    /// </summary>
    /// <param name="timeLapses">Sequence of <see cref="TimeLapse"/> ordered by <see cref="TimeLapse.StartTime"/>.</param>
    public static TimeSpan UnionDurations(this IEnumerable<TimeLapse> timeLapses)
    {
        using (var e = timeLapses.GetEnumerator())
        {
            if (!e.MoveNext()) // no items, no duration
                return TimeSpan.Zero;
            var prev = e.Current;
            var total = prev.EndTime - prev.StartTime; // set running total to duration of 1st interval
            while (e.MoveNext())
            {
                var curr = e.Current;
                if (curr.StartTime < prev.StartTime) throw new Exception($"{nameof(timeLapses)} are not in ascending {nameof(TimeLapse.StartTime)} order.");
                var increase = curr.EndTime - (curr.StartTime > prev.EndTime ? curr.StartTime : prev.EndTime);
                if (increase <= TimeSpan.Zero) continue;
                total += increase;
                prev = curr;
            }
            return total;
        }
    }
