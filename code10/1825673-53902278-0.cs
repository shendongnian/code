    class Person
    {
    	public string Name { get; set; }
    	public int Wage { get; set; }
    	public int Age { get; set; }
    	public override string ToString() =>
    		$"Name: {Name}, Wage: {Wage}, Age: {Age}";
    }
    
    var list = new List<Person>
    {
    	new Person { Name = "Name1", Wage = 1, Age = 1},
    	new Person { Name = "Name1", Wage = 2, Age = 2},
    	new Person { Name = "Name2", Wage = 2, Age = 2},
    	new Person { Name = "Name3", Wage = 2, Age = 2},
    	new Person { Name = "Name3", Wage = 2, Age = 2},
    	new Person { Name = "Name4", Wage = 2, Age = 2},
    	new Person { Name = "Name4", Wage = 2, Age = 2}
    };
    
    var x = list.GroupBy(p => p.GetType().GetProperty("Name").GetValue(p));
    
    foreach(var z in x)
    {
    	WriteLine(z.Key);
    	foreach(var p in z)
    	{
    		WriteLine("\t" + p);
    	}
    }
    /*
        Output:
    Name1
          Name: Name1, Wage: 1, Age: 1
          Name: Name1, Wage: 2, Age: 2
    Name2
          Name: Name2, Wage: 2, Age: 2
    Name3
          Name: Name3, Wage: 2, Age: 2
          Name: Name3, Wage: 2, Age: 2
    Name4
          Name: Name4, Wage: 2, Age: 2
          Name: Name4, Wage: 2, Age: 2
    */
