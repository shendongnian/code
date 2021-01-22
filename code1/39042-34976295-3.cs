    public interface IEmployee 
    {
        public decimal Salary { get; set; }
    }
    public class Employee
    {
        public decimal Salary { get; set; }
    }
    public extension MyPersonExtension extends Person : IEmployee
    {
        private static readonly ConditionalWeakTable<Person, Employee> _employees = 
            new ConditionalWeakTable<Person, Employee>();
    	public decimal Salary
    	{
            get 
            {
                // `this` is the instance of Person
    		    return _employees.GetOrCreate(this).Salary; 
            }
            set 
            {
                Employee employee = null;
                if (!_employees.TryGetValue(this, out employee)
                {
                    employee = _employees.GetOrCreate(this);
                }
                employee.Salary = value;
            }
    	}
    }
    IEmployee person = new Person();
    var salary = person.Salary;
