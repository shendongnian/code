    public SomeClass()
    {
        List<Person> people = new List<Person>();
        people.Add(new Person() { FirstName = "Bob", Surname = "Smith" });
        people.Add(new Person() { FirstName = "Sally", Surname = "Jones" });
        var results =
            from p in people
            let name = p.FirstName + " " + p.Surname
            select new
            {
                FirstName = p.FirstName,
                Surname = p.Surname,
                FullName = name
            };  
    }
    public class Person
    {
        public String FirstName { get; set; }
        public String Surname { get; set; }
    }
