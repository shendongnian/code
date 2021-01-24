    class Person
    {
        public string Name {get; set;}
        public DateTime Dob {get; set;}
        public bool Male {get; set;}
        public int Age => (DateTime.Now - this.Dob).Years // almost correct, TODO: repair
    }
    
    IEnumerable<Person> ReadPersons() {...}  // reads from your input file
