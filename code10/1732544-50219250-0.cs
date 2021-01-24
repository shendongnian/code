    void Main()
    {
    	var emp = new Employee(true);
    	emp.ProductsSold = 100;
    	var emp2 = new Employee();
    	emp2.HoursWorked = 160;
    	
    	var employees = new List<Employee> {emp, emp2};
    	foreach (var e in employees)
    	{
    		e.GetSalaryInformation();
    	}
    	
    }
    
    interface IEmployee
    {
    	void GetSalaryInformation();
    }
    class Employee : IEmployee
    {
    	public int HoursWorked { get; set; }
    	public float ProductsSold {get;set; }
    	private int someFixedRateIMadeupForDemo = 15;
    	private bool _commissionBased;
    	
    	public Employee(bool commisionBased = false)
    	{
    		_commissionBased = commisionBased;
    	}
    	
    	
    	public void GetSalaryInformation()
    	{
    		if (_commissionBased)
    		{
    			Console.WriteLine($"Salary: {ProductsSold * someFixedRateIMadeupForDemo}");
    		}else{
    			Console.WriteLine($"Salary: {HoursWorked * someFixedRateIMadeupForDemo}");
    		}
    	}
    }
