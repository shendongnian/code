    public override int GetHashCode()
    {
        unchecked
        {
            long hash = 17;
    
            hash = hash * 23 + field1.GetHashCode();
            hash = hash * 23 + field2.GetHashCode();
    
            return hash.GetHashCode();
        }
    }
