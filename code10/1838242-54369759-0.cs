    private readonly ApplicationContext_context;
    public PersonRepository(ApplicationContext_contextcontext)
    {
        this._context = context;
    }
    public bool AddPerson(Person entity)
    {
        this._context.Persons.Add(entity);
        this._context.SaveChanges();
        return true;
    }
