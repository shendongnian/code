    class person : IComparable<person>
    { 
      int id; 
      string FirstName; 
      string LastName; 
    
    public int CompareTo(person other)
        {
            //If you want to sort on FirstName
            return FirstName.CompareTo(other.FirstName);
        }
    
    
    } 
