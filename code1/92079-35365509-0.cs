    public Person
    {
        public string Name { get; set; }
        public boolean HasPets { get; set; }
    }
    public void Foo(Person person)
    {
        if (person.Name == null) {
            throw new Exception("Name of person is null.");
            // I was unsure of which exception to throw here.
        }
        Console.WriteLine("Name is: " + person.Name);
    }
