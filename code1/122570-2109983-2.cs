    [Flags]
    public enum Position
        {
            Quarterback = 1,
            Runningback = 2,
            DefensiveEnd = 4,
            Linebacker = 8,
            
            OffensivePosition = Quarterback | Runningback,
            DefensivePosition =  Linebacker | DefensiveEnd, 
    
        };
        
        //strictly for example purposes
        public bool isOffensive(Position pos)
        {
            return !((pos & OffensivePosition) == pos);
        }
