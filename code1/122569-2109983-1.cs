    [Flags]
    public enum Position
        {
            Quarterback = 1,
            Runningback = 2,
            DefensiveEnd = 4,
            Linebacker = 8,
            
            OffensivePositions = Quarterback | Runningback,
            DefensivePositions =  Linebacker | DefensiveEnd, 
    
        };
