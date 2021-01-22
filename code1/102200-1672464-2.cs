    class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null)
                return y == null;
    
            if (y == null)
                return false;
    
            return x.Name == y.Name;
        }
    
        public int GetHashCode(Person obj)
        {
            return obj.Name.GetHashCode();
        }
    }
    ...
    list.Distinct(new PersonComparer()).ToDictionary(x => x.Name);
