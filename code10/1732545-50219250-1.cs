    void Main()
    {
    	var emp = new CommissionedEmployee();
    	emp.ProductsSold = 100;
    	var emp2 = new SalariedEmployee();
    	emp2.HoursWorked = 160;
    	
    	var employees = new List<IEmployee> {emp, emp2};
    	foreach (var e in employees)
    	{
    		e.GetSalaryInformation();
    	}
    	
    }
    
    interface IEmployee
    {
    	void GetSalaryInformation();
    }
    class SalariedEmployee : IEmployee
    {
    	public int HoursWorked { get; set; }
    	private int someFixedRateIMadeupForDemo = 15;
    	
    	
    	public void GetSalaryInformation()
    	{
    		Console.WriteLine($"Salary: {HoursWorked * someFixedRateIMadeupForDemo}");
    	}
    }
    
    class CommissionedEmployee : IEmployee
    {
    	public float ProductsSold {get;set; }
    	private int someFixedRateIMadeupForDemo = 25;
    	public void GetSalaryInformation()
    	{
    		Console.WriteLine($"Salary: {ProductsSold * someFixedRateIMadeupForDemo}");
    	}
    }
