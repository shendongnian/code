    public int GetHashCode(Person obj)
    {
        return obj == null ? 0 
             : StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Name);
    }
