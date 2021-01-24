    public interface IEmployeeRepository
    {
        IEnumerable<BasicEmployeeData> GetBasicEmployeesData(IEnumerable<int> ids);
    }
    
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class EntityFrameworkEmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<BasicEmployeeData> GetBasicEmployeesData(IEnumerable<int> ids)
        {
            using (var context = new EmployeeContext())
            {
                return context.Employees.Where(e => ids.Any(id => id == e)).ToList();
                // I haven't tested if .Any works or whether you should instead do .Join
                // but this is orthogonal to the main question
            }
        }
    }
