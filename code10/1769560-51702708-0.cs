	public IQueryable<Person> People
	{
		get => _includePerson 
            ? Set<Person>()
            : (new[] { new Person() }).AsQueryable();
	}
