    public override bool Equals(object obj)
    {
        if (!(obj is CPlayer)
            return false;
        return Name == (obj as CPlayer).Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
