    public override int GetHashCode()
    {
        unchecked
        {
            return (str1 ?? String.Empty).GetHashCode() +
                (str2 ?? String.Empty).GetHashCode();
        }
    }
