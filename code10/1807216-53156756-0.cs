    public static bool operator <=(Narys lhs, Narys rhs)
    {
        return lhs.Pavarde.CompareTo(rhs.Pavarde);
    }
    public static bool operator >=(Narys lhs, Narys rhs)
    {
        return (lhs.Pavarde.CompareTo() >= rhs.Pavarde.CompareTo()); //syntax error here!
    }
