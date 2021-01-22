    public bool Overlaps(TimePeriod other)
    {
        if (other.EndDate.HasValue && other.EndDate < StartDate)
            return false;
        if (EndDate.HasValue && EndDate < other.StartDate)
            return false;
        if (!EndDate.HasValue && other.EndDate < StartDate)
            return false;
        if (!other.EndDate.HasValue && EndDate < other.StartDate)
            return false;
        return true;
    }
