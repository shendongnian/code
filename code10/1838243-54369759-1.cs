    private readonly ApplicationContext _context;
    public PersonRepository(ApplicationContext context)
    {
        _context = context;
    }
    public bool AddPerson(Person entity)
    {
        _context.Persons.Add(entity);
        _context.SaveChanges();
        return true;
    }
