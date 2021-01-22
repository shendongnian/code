    // Edit #4: This is a proposed design for C# 7 immutable as of June 2015.
    // Compiler will implicitly mark all fields as readonly.
    // Compiler will enforce all fields must be immutable types.
    public immutable class Person
    {
        public Person(string firstName, string lastName, DateTimeOffset birthDay)
        {
            FirstName = firstName; // Properties can be assigned only in the constructor.
            LastName = lastName;
            BirthDay = birthDay; 
        }
    
        public string FirstName { get; } // String is [Immutable], so OK to have as a readonly property
        public string LastName { get; }
        public DateTime BirthDay { get; } // Date is [Immutable] too.
    }
