    public int Compare(Status x, Status y)
    {
        if (IsUnpaid(x)) { return IsAscending? 1 : -1; }
        if (IsUnpaid(y)) { return IsAscending ? -1 : 1; }
        return x.CompareTo(y);
    }
