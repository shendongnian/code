    class Range
    {
        int Left { get; set; }
        int Right { get; set; }
        
        // Constructors, etc.
    }
    
    Range R(int left, int right)
    {
        return new Range(left, right)
    }
    bool Between(this int value, params Range[] ranges)
    {
        for(int i = 0; i < ranges.Length; ++i)
            if(value > ranges[i].Left && value < ranges[i].Right)
                return true;
        return false;
    }
    
    if(x.Between(R(4199, 6800), R(6999, 8200), ...))
