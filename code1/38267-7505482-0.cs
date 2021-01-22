    public class Person  {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    List<Person> people = new List<Person>();
    
    people.Sort(
        delegate(Person x, Person y) {
            if (x == null) {
                if (y == null) { return 0; }
                return -1;
            }
            if (y == null) { return 0; }
            return x.FirstName.CompareTo(y.FirstName);
        }
    );
