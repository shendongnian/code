    public class Person
    {
        private string name;
    
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    
        protected void Assign(Person otherPerson)
        {
            Name = otherPerson.Name;
        }
    }
