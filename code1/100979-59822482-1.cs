    public static int CombineHashes(this ITuple tupled, int seed=1009, int factor=9176)
    {
        var hash = seed;
        for (var i = 0; i < tupled.Length; i++)
        {
            unchecked
            {
                hash = hash * factor + tupled[i].GetHashCode();
            }
        }
        return hash;
    }
    
