    public class EmployeeService
    {
          private readonly UnitOfWork _unitOfWork;
          
          public EmployeeService()
          {
                _unitOfWork = new UnitOfWork();
          }
          public List<Employee> GetAllEmployees()
          {
             return _unitOfWork.Repository<Employee>().GetEntities().ToList();
          }
          public List<string> GetAllEmployeeNames()
          {
             return _unitOfWork.Repository<Employee>().GetEntities().Select(emp => emp.Name).ToList();
          }
    }
