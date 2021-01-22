    public class PersonComparer : IEqualityComparer<Person>
    {
        public static readonly PersonComparer Instance = new PersonComparer();
        // We don't need any more instances
        private PersonComparer() {}
        public int GetHashCode(Person p)
        {
            return p.id;
        }
        public bool Equals(Person p1, Person p2)
        {
            if (Object.ReferenceEquals(p1, p2))
            {
                return true;
            }
            if (Object.ReferenceEquals(p1, null) ||
                Object.ReferenceEquals(p2, null))
            {
                return false;
            }
            return p1.id == p2.id;
        }
    }
    
