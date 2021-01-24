    var employees1 = new List<Employee>
    {
    	new Employee(1, "Thomas", 12),
    	new Employee(2, "Alex", 24),
    	new Employee(3, "Tobias", 13),
    	new Employee(4, "Joshua", 12),
    	new Employee(5, "Thomas", 24)
    };
    
    var employees2 = new List<Employee>
    {
    	new Employee(1, "Thomas", 12),
    	new Employee(2, "Yu", 24),
    	new Employee(3, "Max", 13),
    	new Employee(4, "Joshua", 30),
    	new Employee(5, "Maico", 13)
    };
    
    var duplicates = employees1.Intersect(employees2, new EmployeeComparer());
    
    
    
    class EmployeeComparer : IEqualityComparer<Employee>
    {
    	public bool Equals(Employee employee1, Employee employee2)
    	{
    		if (Object.ReferenceEquals(employee1, null) || Object.ReferenceEquals(employee2, null) ||
    			Object.ReferenceEquals(employee1, employee2)) return false;
    
    		return employee1.Name == employee2.Name && employee1.Age == employee2.Age;
    	}
    
    	public int GetHashCode(Employee employee)
    	{
    		return 0;
    	}
    }
    
    class Employee
    {
    	public Employee(int id, string name, int age)
    	{
    		Id = id;
    		Name = name;
    		Age = age;
    	}
    
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int Age { get; set; }
    }
