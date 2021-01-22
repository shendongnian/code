    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + UpperLimit.GetHashCode();
        hash = hash * 23 + LowerLimit.GetHashCode();
        return hash;
    }
