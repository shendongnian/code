    public class Person
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
    
        public Person(string name)
        {
            this.name = name;  // "this" is required in this case.
        }
    }
