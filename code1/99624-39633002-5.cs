    public class Person
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public Person Boss { get; set; }
    }
    
    public class Company
    {
        public List<Person> Employees { get; set; }
    }
