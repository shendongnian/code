    public override bool Equals(Object obj)
    {
        if (obj == null)
        {
            return false;
        }
        field f = obj as field;
        if (f != null)
        {
            return this == f;
        }
        else
        {
            return obj.Equals(this);
        }
    }
