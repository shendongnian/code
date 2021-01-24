    IQueryable<Person> query = null;
    using (var dbContext = new MyDbcontext())
    {
         query = dbContext.Persons.Where(person => person.Age > 20);
    }
    foreach (var person in query)
    {
          // expect exception: the DbContext is already Disposed
    }
