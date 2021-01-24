    public class Employee
    {
    	public int Number { get; set; }
    	public int GrossPay { get; set; }
    	public int Hours { get; set; }
    	public int PayRate { get; set; }
    	public string Name { get; set; }
    
    }
        
  
   
    void Main()
    {
    	var Employee = new Employee[] { new Employee { Name = "acb", Number = 123 }, new Employee { Name = "nmo", Number = 456 }, new Employee { Name = "xyz", Number = 789 } };
    	var sortedEmpByNum = Employee.OrderBy(x => x.Number);// by number asc
    	var sortedEmpByNubDesc = Employee.OrderByDescending(x => x.Number); //by number desc
    	var sortedEmpByName = Employee.OrderBy(x => x.Name); //by name asc
        //you shoud use this one
    	var finalResult = Employee.OrderBy(x => x.Name)
    						.ThenBy(x => x.Number)
    						.ThenByDescending(x => x.PayRate)
    						.ThenByDescending(x => x.Hours)
    						.ThenByDescending(x => x.GrossPay);
    }
