    byte[] bytes = ...
    bool[] bits = bytes.SelectMany(GetBits).ToArray();
    
    ...
    
    IEnumerable<bool> GetBits(byte b)
    {
        return GetBitsReversed(b).Reverse();
    }
    
    IEnumerable<bool> GetBitsReversed(byte b)
    {
        for(int i = 0; i < 8; i++)
        {
            yield return (b % 2 == 1);
            b /= 2;
        }
    }
