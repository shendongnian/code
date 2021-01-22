    DisplayPerson(londoners.Single());
    DisplayPerson(newYorkers.Single());
    ...
    private static void DisplayPerson(Person person)
    {
        Console.WriteLine("All Details {0}, {1}, {2}, {3}, {4}",
                          person.Age, person.First, 
                          person.Last, person.Living, person.Born);
    }
