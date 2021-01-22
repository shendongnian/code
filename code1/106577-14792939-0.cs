    public class Person
    {
        public Guid Id { get; private set; }
        public Person(Guid id)
        {
            Id = id;
        }
        public Person()
        {
            Id = System.Guid.NewGuid();
        }
        public static bool operator ==(Person p1, Person p2)
        {
            bool rc;
            if (System.Object.ReferenceEquals(p1, p2))
            {
                rc = true;
            }
            else if (((object)p1 == null) || ((object)p1 == null))
            {
                rc = false;
            }
            else
            {
                rc = (p1.Id.CompareTo(p2.Id) == 0);
            }
            return rc;
        }
        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }
        public override bool Equals(object obj)
        {
            bool rc = false;
            if (obj is Person)
            {
                Person p2 = obj as Person;
                rc = (this == p2);
            }
            return rc;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
