    public class EmployeeBL
    {
        private readonly ICreateEmployeeRepository _repo...
        public IResult CreateEmployee(CreateEmployeeRequestDto dto)
        {
             // Business Logic here
             EmployeeCreateDomainState request = ... Mapped from dto
             var rowsAffected = _repo.Execute(item);
             ...
        }
    }
    public class CreateEmployeeRepository : ICreateEmployeeRepository
    {
        public CreateEmployeeRepository (IoC inect stuff)...
        public int Execite(EmployeeCreateDomainState request)
        {
            using (var empCtx = EmpDbContextFactory.Create())
            {
                 var employeeEntity = ... // Map from request
                 var employeeAddressEntity = ... // Map from request
                 empCtx.Employees.Add(employeeEntity);                 
                 empCtx.EmployeeAddresses.Add(employeeAddressEntity );
                 return empCtx.SaveChanges();
            }
        }
    }
