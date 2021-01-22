    class  Person
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public Person(string firstName, string lastName) {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
    class PersonReadOnly : Person
    {
        public override string FirstName { get { return base.FirstName; } set { throw new Exception("setting a readonly field"); } }
        public override string LastName { get { return base.LastName; } set { throw new Exception("setting a readonly field"); } }
        public PersonReadOnly(string firstName, string lastName) : base(firstName, lastName)
        {
        }
        public PersonReadOnly(Person p) : base(p.FirstName, p.LastName)
        {
        
        }
    }
    class List1
    {
        public List<Person> l1 = new List<Person>();
        public List1()
        {
            l1.Add(new Person("f1", "l1"));
            l1.Add(new Person("f2", "l2"));
            l1.Add(new Person("f3", "l3"));
            l1.Add(new Person("f4", "l4"));
            l1.Add(new Person("f5", "l5"));
        }
        public IEnumerable<Person> Get()
        {
            foreach (Person p in l1)
            {
                yield return new PersonReadOnly(p);
            }
            //return l1.AsReadOnly(); 
        }
    }  
    class Program
    {
        static void Main(string[] args)
        {
            List1 list1Instance = new List1();
            List<Person> p = new List<Person>(list1Instance.Get());           
            UpdatePersons(p);
            bool sameFirstName = (list1Instance.l1[0].FirstName == p[0].FirstName);
        }
        private static void UpdatePersons(List<Person> list)
        {
            // readonly message thrown
            list[0].FirstName = "uf1";
        }
