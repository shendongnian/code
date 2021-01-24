    public override int GetHashCode()
    {
        unchecked
        {
            return ((int)2166136261 * 16777620) ^ this.Id.GetHashCode();
        }
    }
