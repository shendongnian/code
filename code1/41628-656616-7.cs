    public class Person : IPerson
    {
        public int ID { get; protected set; }
        public string FullName { get { return FirstName + " " + LastName; } } 
    }
