    bool Between(this int value, params int[] values)
    {
        // Should be even number of items
        Debug.Asset(values.Length % 2 == 0); 
        for(int i = 0; i < values.Length; i += 2)
            if(!x.Between(values[i], values[i + 1])
                return false;
        return true;
    }
    if(x.Between(4199, 6800, 6999, 8200, ...)
