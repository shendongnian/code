    public static bool operator <=(Narys lhs, Narys rhs)
    {
        return lhs.Pavarde.CompareTo(rhs.Pavarde); //syntax error here!
    }
    public static bool operator >=(Narys lhs, Narys rhs)
    {
        return (lhs.Pavarde.CompareTo() >= rhs.Pavarde.CompareTo()); //syntax error here!
    }
