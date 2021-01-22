    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
    ...
    List<Person> people = new List<Person>();
    people.Add(new Person {FirstName = "Fred", ... });
