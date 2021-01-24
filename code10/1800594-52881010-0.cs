    public int CompareTo(Respondant other)
    {
        int x = ((int)this.Role).CompareTo((int)other.Role);
        if(x == 0)
            return this.Name.CompareTo(other.Name);
        else
            return x;
    }
