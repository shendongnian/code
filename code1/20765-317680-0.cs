    static IEnumerable<Person> GetAllPeople()
    {
        return new List<Person>()
        {
            new Person() { Name = "George", Surname = "Bush", City = "Washington" },
            new Person() { Name = "Abraham", Surname = "Lincoln", City = "Washington" },
            new Person() { Name = "Joe", Surname = "Average", City = "New York" }
        };
    }
    static IEnumerable<Person> GetPeopleFrom(this IEnumerable<Person> people,  string where)
    {
        foreach (var person in people)
        {
            if (person.City == where) yield return person;
        }
        yield break;
    }
    static IEnumerable<Person> GetPeopleWithInitial(this IEnumerable<Person> people, string initial)
    {
        foreach (var person in people)
        {
            if (person.Name.StartsWith(initial)) yield return person;
        }
        yield break;
    }
    static void Main(string[] args)
    {
        var people = GetAllPeople();
        foreach (var p in people.GetPeopleFrom("Washington"))
        {
            // do something with washingtonites
        }
        foreach (var p in people.GetPeopleWithInitial("G"))
        {
            // do something with people with initial G
        }
        foreach (var p in people.GetPeopleWithInitial("P").GetPeopleFrom("New York"))
        {
            // etc
        }
    }
