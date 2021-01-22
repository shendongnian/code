    public IEnumerable<Person> ReadPeople(string name)
    {
        using (var reader = OpenReader(...))
        {
            // loop through the reader and create Person objects
            for ...
            {
                var person = new Person();
                ...
                yield return person;
            }
        }
    }
