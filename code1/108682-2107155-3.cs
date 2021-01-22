    public MockPerson() : IPerson
    {
    public String FirstName { get { return "John"; } }
    public String LastName { get { return "Smith"; } } 
    public Email EmailAddress { get { return new Email("John@smith.com"); } }
    }
