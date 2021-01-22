    public class Person
    {
        public string Name { get; set; }
        public IList<Role> Roles { get; private set; }
        
        public Person()
        {
            Roles = new List<Role>();
        }
    }
