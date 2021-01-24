    public static bool DoAnyOverlap(List<Period> periods)
    {
        if (periods == null || periods.Count < 2) return false;
        var ordered = periods.Where(p => p != null).OrderBy(p => p.StartTime).ToList();
        for (var i = 0; i < ordered.Count - 1; i++)
        {
            if (ordered[i].StartTime <= ordered[i + 1].EndTime &&
                ordered[i].EndTime >= ordered[i + 1].StartTime)
            {
                return true;
            }
        }
        return false;
    }
