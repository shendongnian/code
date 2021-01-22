    class Person : IComparable<Person>
    {
        int id;
        string FirstName;
        string LastName;
        public int CompareTo(Person other)
        {
            return LastName.CompareTo(other.LastName);
        }
    }
