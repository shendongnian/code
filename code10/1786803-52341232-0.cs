	public class EmployeeManager : IEmployeeManager
	{
	    private readonly IEmployeeRepository _employeeRepository;
	    private IEnumerable<Employee> _employees;
	    public EmployeeManager(IEmployeeRepository employeeRepository)
	    {
	        _employeeRepository = employeeRepository;
	    }
	    public IEnumerable<Employee> GetEmployees()
	    {
	        return
	            _employees ?? (_employees = _employeeRepository.GetAll());
	    }
	}
