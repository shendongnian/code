    int FindInterpolated(DateTime needle)
    {
        try
        {
            DateTime lower = haystack.First(key => haystack[key] <= needle);
            DateTime upper = haystack.Last(key => haystack[key] >= needle);
            int v1 = haystack[lower];
            int v2 = haystack[upper];
            long ticksLower = lower.Ticks;
            long ticksUpper = upper.Ticks;
            return (v1 * ticksLower + v2 * ticksUpper) / (ticksLower + ticksUpper);
        }
        catch (InvalidOperationException)
        {
            // thrown if needle is out of range
            // (not between smallest and biggest keys in the haystack)
            ...
        }
    }
