    public class Person
    {
        public Person(string name)
        {
            this.Name= name;
        }
        public string Name { get; private set; }
        public List<Person> Childs{ get; private set; }
    }
