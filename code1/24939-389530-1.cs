    public static bool operator ==(Customer a, Customer b)
    {
        if(object.ReferenceEquals(a,b)
        { return true; }
        else if(((object)a == null) || ((object)b == null))
             {return false;}
        else if(a.Id == b.Id)
             {return true;}
    
        return false;
    }
    
    public static bool operator !=(Customer a, Customer b)
    {
    return !(a==b);
    }
