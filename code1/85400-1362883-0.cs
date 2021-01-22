    public override int GetHashCode()
    {
        int result = 17;
        result = result * 31 + Min.GetHashCode();
        result = result * 31 + Max.GetHashCode();
        result = result * 31 + Upperbound ? 1 : 0;
    }
