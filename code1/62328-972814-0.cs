    //add this code to class ThreeDPoint as defined previously
    //
    public static bool operator ==(ThreeDPoint a, ThreeDPoint b)
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
    
        // Return true if the fields match:
        return a.x == b.x && a.y == b.y && a.z == b.z;
    }
    
    public static bool operator !=(ThreeDPoint a, ThreeDPoint b)
    {
        return !(a == b);
    }
