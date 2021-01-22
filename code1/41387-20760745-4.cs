    class Person: IPerson
    {
        public Person(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                throw new System.ArgumentException();
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    
    }
    
    ...
    
    class PersonFactory: IPersonFactory
    {
        public IPerson CreatePerson(string firstName, string lastName)
        {
            return new Person(firstName, lastName);
        }
    }
    ...
    void Consumer(IPersonFactory factory)
    {
        IPerson person = factory.CreatePerson("John", "Doe");
        Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
    }
