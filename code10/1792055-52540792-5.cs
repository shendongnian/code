    public override int GetHashCode()
    {
        int hash = 57;
        var props = GetType().GetProperties();
        foreach (var p in props)
        {
            if (p.GetValue(this, null) != null)
                hash = 27 ^ hash ^ p.GetValue(this, null).GetHashCode();
    
        }
        return hash;
    }
