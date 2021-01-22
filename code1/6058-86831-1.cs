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
            public static Person Create(string name)
            {
                return new Person(name);
            }
        }
        protected string name;
        public string Name
        {
            get { return this.name; }
        }
        protected Person(string name)
        {
            this.name = name;
        }
    }
    
    Person p = Person.Editor.Create("John");
    Person.Editor e = new Person.Editor(p);
    e.SetName("Jane");
