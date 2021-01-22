    public override int GetHashCode()
    {
        int hash = 37;
        hash = hash * 23 + base.GetHashCode();
        hash = hash * 23 + Id.GetHashCode();
        return hash;
    }
