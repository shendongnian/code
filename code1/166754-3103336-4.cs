    public int GetHashCode()
    {
        return (FirstName.GetHashCode()+1) ^ (LastName.GetHashCode()+2);
    }
    
    public bool Equals(Object obj)
    {
        Person p = obj as Person;
        if (p == null) 
            return false;
        
        return this.Firstname == p.FirstName && this.LastName == p.Lastname;
    }
