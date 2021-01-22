    class Person
    {
            public int Id { get; set; }
            public string Name { get; set; }
    }
    
    class PersonWithAge : Person
    {
            // Id and Name are inherited from Person
            public int Age { get; set; }
    }
