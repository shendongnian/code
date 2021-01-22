    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == typeof(SecurableResourcePermission) && Equals((SecurableResourcePermission)obj);
    }
    public bool Equals(SecurableResourcePermission obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.ResourceUid == ResourceUid && Equals(obj.ActionCode, ActionCode) && Equals(obj.AllowDeny, AllowDeny);
    }
    public override int GetHashCode()
    {
        unchecked
        {
            int result = (int)ResourceUid;
            result = (result * 397) ^ (ActionCode != null ? ActionCode.GetHashCode() : 0);
            result = (result * 397) ^ AllowDeny.GetHashCode();
            return result;
        }
    }
