    var live = new List<Live>();
    lives.Add(new Live
    {
        Person = new Person
        {
            FirstName = "Joe",
            LastName = "Doe"
        },
        Cities = new List<City>(
        new City[]
        {
            new City {
                Name = "LA"
            },
            new City {
                Name = "NY"
            }
        }),
        Number = 31
    });
