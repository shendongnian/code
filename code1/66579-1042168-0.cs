    public static bool operator ==(ClauseBE a, ClauseBE b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        {
            return true;
        }
    
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        {
            return false;
        }
    
        return a.Equals(b);
    }
    
    public static bool operator !=(ClauseBE a, ClauseBE b)
    {
        return !(a == b);
    }
