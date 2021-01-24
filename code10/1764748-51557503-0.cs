    public async Task<Person> searchPerson(string name)
    {
        // ...
        List<Person> peopleList = await Task.Run(() => myCollection.AsQueryable<Person>().Where(e => e.Name == name).ToList<Person>());
        // ...
    }
(maybe you can skip the Task.Run and use an async version of the MongoDB client).
