    public override int GetHashCode()
    {
        return MemberwiseEqualityComparer<Foo>.Default.GetHashCode(this);
    }
 
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
 
        return Equals(obj as Foo);
    }
 
    public override bool Equals(Foo other)
    {
        return MemberwiseEqualityComparer<Foo>.Default.Equals(this, other);
    }
