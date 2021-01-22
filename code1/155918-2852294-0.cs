    // Bad code; do not use, will throw exception.
    IEnumerable<Person> people;
    using (var context = new TestDataContext())
    {
        people = context.Person;
    }
    foreach (Person p in people)
    {
        Console.WriteLine(p.ID);
    }
