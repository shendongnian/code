    public bool IsTimeInGivenPeriods(TimeToCheck, Periods)
    {
          return Periods?.Any(p=>  p.Start <= TimeToCheck && p.End < TimeToCheck )  ?? false;
    
    }
