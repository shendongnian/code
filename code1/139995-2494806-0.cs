    PersonDetails d = new PersonDetails
    {
        new Person {Age = 29, Born = "Timbuk Tu", First = "Joe", 
                   Last = "Bloggs", Living = "London"},
        new Person { Age = 29, Born = "Timbuk Tu", First = "Foo", 
                    Last = "Bar", Living = "NewYork" }
    };
    var peopleOfCorrectAge = d.Where(a => a.Age == 29);
    var londoners = peopleOfCorrectAge.Where(p => p.Living == "London");
    var newYorkers = peopleOfCorrectAge.Where(p => p.Living == "New York");
    var londoner = londoners.Single();
    var newYorker = newYorker.Single();
    Console.WriteLine("All Details {0}, {1}, {2}, {3}, {4}",
                      londoner.Age, londoner.First, 
                      londoner.Last, londoner.Living, londoner.Born);
    Console.WriteLine("All Details {0}, {1}, {2}, {3}, {4}",
                      newYorker.Age, newYorker.First, 
                      newYorker.Last, newYorker.Living, newYorker.Born);
