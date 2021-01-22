    public static bool Equals(object x, object y)
    {
        if (x == y) // Reference equality only; overloaded operators are ignored
        {
            return true;
        }
        if (x == null || y == null) // Again, reference checks
        {
            return false;
        }
        return x.Equals(y); // Safe as we know x != null.
    }
