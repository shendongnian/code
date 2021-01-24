    public static bool operator <=(Narys lhs, Narys rhs)
    {
        return lhs.Pavarde.CompareTo(rhs.Pavarde) <= 0;
    }
    public static bool operator >=(Narys lhs, Narys rhs)
    {
        return (lhs.Pavarde.CompareTo(rhs.Pavarde)) >= 0;
    }
