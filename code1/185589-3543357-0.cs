    public class PersonComparer : EqualityComparer<Person>
    {
        public override bool Equals(Person a, Person b)
        {
            return a.Id == b.Id && a.Name == b.Name;
        }
    }
