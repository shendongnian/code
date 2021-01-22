    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(this.object1);
        hash.Add(this.object2);
        return hash.ToHashCode();
    }
