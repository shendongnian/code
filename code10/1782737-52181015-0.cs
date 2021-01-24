    public class EmployeeSearcher
    {
      private IEnumerable<Employee> _employees;
      public EmployeeSearcher(IEnumerable<Employee> employees)
      {
        _employees = employees;
      }
      public Employee Search(int id)
      {
        var employee = _employees.SingleOrDefault(e => e.EmployeeID == id);
        if (employee == null) throw new Exception($"Employee not found: {id}");
        if (employee.ManagerID.HasValue)
          employee.Manager = FindManagerRecursive(employee);
        return employee;
      }
      private Employee FindManagerRecursive(Employee employee)
      {
        if (employee.ManagerID.HasValue)
        {
          var manager = _employees.SingleOrDefault(e => e.EmployeeID == employee.ManagerID.Value);
          if (manager == null) throw new Exception("Manager not found: {employee.ManagerID}");
          employee.Manager = manager;
        }
        return employee;
      }
    }
