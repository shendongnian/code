    void Main()
    {
    	var employees = new[]
    	{
    		new Employee { Id = 20, Name = "Bob" },
    		new Employee { Id = 10, Name = "Kirk NM" },
    		new Employee { Id = 48, Name = "Rick NM" },
    		new Employee { Id = 42, Name = "Dick" },
    		new Employee { Id = 43, Name = "Harry" },
    		new Employee { Id = 44, Name = "Joe" },
    		new Employee { Id = 45, Name = "Steve NM" },
    		new Employee { Id = 46, Name = "Jim NM" },
    		new Employee { Id = 30, Name = "Frank"},
    		new Employee { Id = 47, Name = "Dave NM" },
    		new Employee { Id = 49, Name = "Alex NM" },
    		new Employee { Id = 50, Name = "Phil NM" },
    		new Employee { Id = 51, Name = "Ed NM" },
    		new Employee { Id = 52, Name = "Ollie NM" },
    		new Employee { Id = 41, Name = "Bill" },
    		new Employee { Id = 53, Name = "John NM" },
    		new Employee { Id = 54, Name = "Simon NM" }
    	};
    
    	var managers = new[]
    	{
    		new Manager { EmployeeId = 20 },
    		new Manager { EmployeeId = 30 },
    		new Manager { EmployeeId = 41 },
    		new Manager { EmployeeId = 42 },
    		new Manager { EmployeeId = 43 },
    		new Manager { EmployeeId = 44 }
    	};
    	
    	System.Diagnostics.Stopwatch watch1 = new System.Diagnostics.Stopwatch();
    
    	int max = 1000000;
    	
    	watch1.Start();
    	List<Employee> nonManagers1 = new List<Employee>();
    	foreach (var item in Enumerable.Range(1,max))
    	{
    		nonManagers1 = (from employee in employees where !(managers.Any(x => x.EmployeeId == employee.Id)) select employee).ToList();
    		
    	}
    	nonManagers1.Dump();
    	watch1.Stop();
    	Console.WriteLine("Any: " + watch1.ElapsedMilliseconds);
    	
    	watch1.Restart();		
    	List<Employee> nonManagers2 = new List<Employee>();
    	foreach (var item in Enumerable.Range(1,max))
    	{
    		nonManagers2 =
    		(from employee in employees
    		join manager in managers
    			on employee.Id equals manager.EmployeeId
    		into tempManagers
    		from manager in tempManagers.DefaultIfEmpty()
    		where manager == null
    		select employee).ToList();
    	}
    	nonManagers2.Dump();
    	watch1.Stop();
    	Console.WriteLine("temp table: " + watch1.ElapsedMilliseconds);
    
    	watch1.Restart();		
    	List<Employee> nonManagers3 = new List<Employee>();
    	foreach (var item in Enumerable.Range(1,max))
    	{
    		nonManagers3 = employees.Except(employees.Join(managers, e => e.Id, m => m.EmployeeId, (e, m) => e)).ToList();
    	}
    	nonManagers3.Dump();
    	watch1.Stop();
    	Console.WriteLine("Except: " + watch1.ElapsedMilliseconds);
    	
    	watch1.Restart();		
    	List<Employee> nonManagers4 = new List<Employee>();
    	foreach (var item in Enumerable.Range(1,max))
    	{
    		HashSet<int> managerIds = new HashSet<int>(managers.Select(x => x.EmployeeId));
    		nonManagers4 = employees.Where(x => !managerIds.Contains(x.Id)).ToList();
    		
    	}
    	nonManagers4.Dump();
    	watch1.Stop();
    	Console.WriteLine("HashSet: " + watch1.ElapsedMilliseconds);
    	
    	  watch1.Restart();
    	  List<Employee> nonManagers5 = new List<Employee>();
    	  foreach (var item in Enumerable.Range(1, max))
    	  {
    				   bool[] test = new bool[managers.Max(x => x.EmployeeId) + 1];
    				   foreach (var manager in managers)
    				   {
    						test[manager.EmployeeId] = true;
    				   }
    				   
    				   nonManagers5 = employees.Where(x => x.Id > test.Length - 1 || !test[x.Id]).ToList();
    				   
    				   
    	  }
    	  nonManagers5.Dump();
    	  watch1.Stop();
    	  Console.WriteLine("Native array call: " + watch1.ElapsedMilliseconds);
    
    	  watch1.Restart();
    	  List<Employee> nonManagers6 = new List<Employee>();
    	  foreach (var item in Enumerable.Range(1, max))
    	  {
    				   bool[] test = new bool[managers.Max(x => x.EmployeeId) + 1];
    				   foreach (var manager in managers)
    				   {
    						test[manager.EmployeeId] = true;
    				   }
    				   
    				   nonManagers6 = employees.Where(x => x.Id > test.Length - 1 || !test[x.Id]).ToList();
    	  }
    	  nonManagers6.Dump();
    	  watch1.Stop();
    	  Console.WriteLine("Native array call 2: " + watch1.ElapsedMilliseconds);
    }
    
    public class Employee
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    public class Manager
    {
    	public int EmployeeId { get; set; }
    }
