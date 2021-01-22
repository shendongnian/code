    public static bool operator ==(Region r1, Region r2)
    {
        if (object.ReferenceEquals( r1, r2)) {
            // handles if both are null as well as object identity
            return true;
        }
        if ((object)r1 == null || (object)r2 == null)
        {
           return false;
        }        
        return (r1.Cmr.CompareTo(r2.Cmr) == 0 && r1.Id == r2.Id);
    }
    public static bool operator !=(Region r1, Region r2)
    {
        return !(r1 == r2);
    }
    
