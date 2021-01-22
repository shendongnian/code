    public override int GetHashCode()
    {
        long internalTicks = this.InternalTicks;
        return (((int) internalTicks) ^ ((int) (internalTicks >> 0x20)));
    }
 
