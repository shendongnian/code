    public static bool operator ==(Complex lhs, Complex rhs)
    {
        if (Object.ReferenceEquals(lhs, null))
        {
            return Object.ReferenceEquals(rhs, null);
        }
        return lhs.Equals(rhs);
    }
    public static bool operator !=(Complex lhs, Complex rhs)
    {
        return !(lhs == rhs);
    }
