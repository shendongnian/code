    public class EmployeeService
    {
          private readonly UnitOfWork _unitOfWork;
          
          public EmployeeService()
          {
                _unitOfWork = new UnitOfWork();
          }
          public List<Employee> GetAllEmployees()
          {
             _unitOfWork.Repository<Employee>().GetEntities().ToList();
          }
          public List<string> GetAllEmployeeNames()
          {
             _unitOfWork.Repository<Employee>().GetEntities().Select(emp => emp.Name).ToList();
          }
    }
