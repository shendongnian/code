    public class EmployeeService
    {
          private readonly IUnitOfWork _unitOfWork;
          
          public EmployeeService(IUnitOfWork unitOfWork)
          {
                _unitOfWork = unitOfWork;
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
 
