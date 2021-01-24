    class Person
    {
    	public int Id { get; set; }
    }
    
    class Employee : Person
    {
    }
    
    // code somewhere else
    
    Employee employee = new Employee { Id = 10 };
