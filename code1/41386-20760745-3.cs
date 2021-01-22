    class PersonBuilder: IPersonBuilder
    {
        IPerson BuildPerson(IContext context)
        {
            Person person = new Person();
            person.FirstName = context.GetFirstName();
            person.LastName = context.GetLastName();
            return person;
        }
    }
    
    ...
    
    void Consumer(IPersonBuilder builder, IContext context)
    {
        IPerson person = builder.BuildPerson(context);
        Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
    }
