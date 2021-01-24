    public override int GetHashCode()
    {
        if (!this.HasValue)
        {
            return 0;
        }
        return this.value.GetHashCode();
    }
