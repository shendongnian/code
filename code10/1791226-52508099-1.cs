    void Main()
    {
    	var persons = new []
    	{
    		new Person { Id = 1, Name = "Alice", Active = true },
    		new Person { Id = 2, Name = "Bob", Active = false },
    		new Person { Id = 3, Name = "Charlie", Active = true },
    	};
    	
    	Func<Person, bool> whereClause;
    	
    	var isActive = true; // change the value here
    	if (isActive)
    		whereClause = x => x.Active == true;
    	else
    		whereClause = x => x.Active == false;
    	
    	var query = persons.Where(whereClause);
    	query.Dump();	
    }
    
    class Person
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public bool Active { get; set; }
    }
