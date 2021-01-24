    public class Data
    {
    	public string Name { get; set; }
    	private int _Salary;
    	public int Salary
    	{
    		get
    		{
    			return _Salary;
    		}
    		set
    		{
    			_Salary = value;
    			SalaryChanged?.Invoke();
    		}
    	}
    
    	public Action SalaryChanged { get; set; }
    }
