    class Range
    {
        int Left { get; set; }
        int Right { get; set; }
        
        // Constructors, etc.
    }
    
    bool R(int left, int right)
    {
        return new Range(left, right)
    }
    bool Between(this int value, params Range[] ranges)
    {
        for(int i = 0; i < values.Length; ++i)
            if(!x.Between(values[i].Left, values[i].Right)
                return false;
        return true;
    }
    
    if(x.Between(R(4199, 6800), R(6999, 8200), ...))
