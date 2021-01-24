    public bool Intersect(DateSpan other)
    {
        return (this.StartDate > other.StartDate && this.StartDate < other.EndDate) ||
               (this.EndDate > other.StartDate && this.EndDate < other.EndDate);
    }
