    public int GetHashCode()
    {
        return FirstName.GetHashCode() ^ LastName.GetHashCode();
    }
    
    public bool Equals(Person obj)
    {
        Person p = obj as Person;
        if (p == null) 
            return false;
        
        return this.GetHashCode() == p.GetHashCode();
    }
