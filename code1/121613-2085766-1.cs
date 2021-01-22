    public override int GetHashCode()
    {
        unchecked
        {
            int result = a;
            result = (result * 397) ^ (b != null ? b.GetHashCode() : 0);
            result = (result * 397) ^ c.GetHashCode();
            return result;
        }
    }
