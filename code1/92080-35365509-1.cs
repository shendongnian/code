    public Person
    {
        public string Name { get; private set; }
        public boolean HasPets { get; set; }
        public Person(string name)
        {
            if (name == null) {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }
    }
    public void Foo(Person person)
    {
        Console.WriteLine("Name is: " + person.Name);
    }
