    // Helper method to check if two numbers within offset
    private IEnumerable<int> WithinOffset(int? previous, int current, int offset)
    {
        if (previous.HasValue == false)
        {
            yield break;
        }
        var difference = Math.Abs(previous.Value, current);
        if (difference > 0 && difference <= offset)
        {
            yield return previous.Value;
            yield return current;
        }
    }
    var clock = Stopwatch.Start();
    var offset = 2;
    var result = 
        givenData.OrderBy(number => number)
                 .Aggregate(
                     (All: Enumerable.Empty<int>(), Last: default(int?)),
                     (summary, current) => 
                     {
                         var withinOffset = WithinOffset(summery.Last, current, offset);
                         var all = summary.All.Concat(withinOffset);
                         return (all, current);
                     },
                     (summary) => summary.All.ToHashSet().ToList());
    clock.Stop();
    var ticks = clock.ElapsedTicks;
                            
