    public class Person 
    {
         public string Name { get; set; }
    } 
    public class Teacher : Person { } 
    public class MailingList
    {
        public void Add(IEnumerable<out Person> people) { ... }
    }
    public class School
    {
        public IEnumerable<Teacher> GetTeachers() { ... }
    }
    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person a, Person b) 
        { 
            if (a == null) return b == null ? 0 : -1;
            return b == null ? 1 : Compare(a,b);
        }
        private int Compare(string a, string b)
        {
            if (a == null) return b == null ? 0 : -1;
            return b == null ? 1 : a.CompareTo(b);
        }
    }
