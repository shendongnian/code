    public static bool DateRangesOverlap(DateRange range1, DateRange range2)
    {
      return (range1.StartDate >= range2.StartDate && range1.StartDate <= range2.EndDate) || 
             (range1.EndDate >= range2.StartDate && range1.EndDate <= range2.EndDate);
    }
