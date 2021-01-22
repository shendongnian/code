    public static bool operator ==(MyDataObject a, MyDataObject b)
    {
        // If both are null, or both are same instance, return true.
        if (System.Object.ReferenceEquals(a, b))
        {
           return true;
        }
        // If one is null, but not both, return false.
        if (((object)a == null) || ((object)b == null))
        {
           return false;
        }
        // Otherwise use equals
        return a.Equals(b);
    }
