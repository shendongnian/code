    public class Person 
    {
        public string Name { get; set; }
        public string Address { get; set; }
    
        public static readonly Person Default = new Person() 
        {
            Name = "Some Name",
            Address = "Some Address"
        };
    }
    
    ...
    
    public static void Main(string[] args)
    {
        string address = String.Empty;
        
        Person person = Person.Default;
    
        //the rest of your code
    }
