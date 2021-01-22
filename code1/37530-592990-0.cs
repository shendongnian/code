    // Edit #4: This is a proposed design for C# 7 immutable. 
    // Compiler will implicitly mark all fields as readonly.
    // Compiler will enforce all fields must be immutable types.
    public immutable class Person
    {
        public Person(string firstName, string lastName, DateTimeOffset birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay; 
        }
    
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDay { get; }
    }
