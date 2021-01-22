      public struct EmployeeId 
      { 
          private int empId;
          public int EmployeeId { get { return empId; } set { empId = value; } }
          public EmployeeId(int employeId) { empId = employeeId; }
      }
      
      public struct DepartmentId 
      {
       // analogous content
      }
     // Now it's fine, as the parameters are defined as distinct types...
     public List<Employee> GetEmployees(EmployeeId supervisorId);
     public List<Employee> GetEmployees(DepartmentId  departmentId);
