    class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.FirstAndLastName.Equals(y.FirstAndLastName, StringComparison.OrdinalIgnoreCase);
        }
        public int GetHashCode(Person obj)
        {
            return obj.FirstAndLastName.ToUpper().GetHashCode();
        }
    }
    class Person
    {
        public string FirstAndLastName { get; set; }
    }
