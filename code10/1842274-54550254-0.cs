    string fieldsToSelect = "new Person { FirstName = p.FirstName }"; //Pass this as parameter.
    public static IQueryable<Person> GetPersons(TestContext context, string fieldsToSelect) 
    {
        IQueryable<Person> query = context.Persons.Select(fieldsToSelect);
    }
