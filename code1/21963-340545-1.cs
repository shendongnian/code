    public override int GetHashCode(Customer obj)
    {
        unchecked
        {
            return ((obj.Id != null ? obj.Id.GetHashCode() : 0) * 397) 
                ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
        }
    }
