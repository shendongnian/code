    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            return false;
        }
        return Equals(this, obj as Shift);
    }
