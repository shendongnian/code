    void Main()
    {
    	var persons = new []
    	{
    		new Person { Id = 1, Name = "Alice", Active = true },
    		new Person { Id = 2, Name = "Bob", Active = false },
    		new Person { Id = 3, Name = "Charlie", Active = true },
    	};
    	
    	Func<Person, bool> fActive = x => x.Active == true;
    	var activePersons = persons.Where(fActive);
    	activePersons.Dump("Active persons");
    	Func<Person, bool> fInactive = x => x.Active == false;
    	var inactivePersons = persons.Where(fInactive);
    	inactivePersons.Dump("Inactive persons");
    }
    
    class Person
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public bool Active { get; set; }
    }
