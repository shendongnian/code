    static void Main()
    {
       MainAsync.Wait();  // add some error handling
    }
    // option 1, async and sequential
    static Task MainAsync()
    {
        var repository = new PersonRepository();
        List<Person> people1 = await repository.GetAsync();
        List<Person> people2 = await repository.GetAsync();
        // use the results
    }
    // option 2, parallel
    static Task MainAsync()
    {
        var repository = new PersonRepository();
  
       Task<List<Person>> peopleTask1 = repository.GetAsync();
       Task<List<Person>> peopleTask2 = repository.GetAsync();
       await Task.WaitAll(peopleTask1 , peopleTask2);
       List<Person> people1 = peopleTask1.Result;  // should be completed now
       List<Person> people2 = peopleTask2.Result;  
       // use the results
    }
