    //your going to struggle to do DI with internal classes, make them public
    public class EmployeeBal : IEmployeeBal
	{
       //
	} 
    
    public interface IEmployeeBal
	{
        void Add(Employee entity);
        void Delete(Employee entity);
        IEnumerable<Employee> GetAll();
        Department Department {get; set;}
	}
    
    public class StickTogether
	{
        private readonly IEmployeeBal _employee;
        private readonly IDepartmentBal _department;
    
        public StickTogether(IEmployeeBal  employee, IDepartmentBal  department)
		{
            _employee = employee;
            _department = department;
        }
    
        public void Create()
        {
            _employee.Add(new Employee());
            _department.Add(new Department());
            _employee.Department = _department; //not accessible which has a sense
        }
    }
