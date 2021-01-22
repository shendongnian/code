    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            return false;
        }
        return Equals(this, obj as Shift);
    }
    public override int GetHashCode()
    {
        return this.GetHashCode(this);
    }
