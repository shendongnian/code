    public bool Overlaps(TimePeriod other)
    {
        bool isOtherEarlier = this.StartDate > other.StartDate;
        TimePeriod earlier = isOtherEarlier  ? other : this;
        TimePeriod later = isOtherEarlier ? this : other;
        return !earlier.EndDate.HasValue || earlier.EndDate > later.StartDate;
    }
