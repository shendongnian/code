    public int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            // Maybe nullity checks, if these are objects not primitives!
            hash = hash * 23 + Zoom.GetHashCode();
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }
    }
