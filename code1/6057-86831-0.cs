    public class Person
    {
        public class Editor
        {
            private readonly Person person;
            public Editor(Person p)
            {
                person = p;
            }
            public void SetName(string name)
            {
                person.name = name;
            }
        }
        protected string name;
        public string Name
        {
            get { return this.name; }
        }
        public Person(string name)
        {
            this.name = name;
        }
    }
    
    Person p = new Person("John");
    Person.Editor e = new Person.Editor(p);
    e.SetName("Jane");
