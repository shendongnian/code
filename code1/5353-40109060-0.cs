    // If both are null, or both are same instance, return true.
    if (System.Object.ReferenceEquals(a, b))// using ReferenceEquals
    {
        return true;
    }
    // If one is null, but not both, return false.
    if (((object)a == null) || ((object)b == null))// using casting the type to Object
    {
        return false;
    }
