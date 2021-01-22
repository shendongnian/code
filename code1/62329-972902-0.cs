    public static Boolean operator ==(ClauseBE a, ClauseBE b)
    {
        return ((a != null) && (b != null) && (a._id == b._id));
    }
    public static Boolean operator !=(ClauseBE a, ClauseBE b)
    {
        return !(a == b);
    }
    public override Boolean Equals(Object obj)
    {
        return ((obj is ClauseBE) && (this == (ObjectBE) obj));
    }
    public override Boolean Equals(ClauseBE other)
    {
        return (this == other);
    }
