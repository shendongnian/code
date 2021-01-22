    public override bool Equals(object obj)
    {
        var k = obj as Key;
        if (k != null)
        {
            return this.name == k.name;
        }
        return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        return this.name.GetHashCode();
    }
