      public struct EmployeeId
      { 
          public int val;
          public EmployeeId(int employeeId) { val = employeeId; }
      }
      public struct HRId
      { 
          public int val;
          public HRId(int hrId) { val = hrId; }
      }
      public class Employee 
      {
          public int EmployeeId;
          public int HrId;
          // other stuff
      }
      public class Employees: Collection<Employee>
      {
          public Employee this[EmployeeId employeeId]
          {
              get
                 {
                    foreach (Employee emp in this)
                       if (emp.EmployeeId == employeeId.val)
                          return emp;
                    return null;
                 }
          }
          public Employee this[HRId hrId]
          {
              get
                 {
                    foreach (Employee emp in this)
                       if (emp.HRId == hrId.val)
                          return emp;
                    return null;
                 }
          }
          // (or using new C#6+ "expression-body" syntax)
          public Employee this[EmployeeId empId] => 
                 this.FirstorDefault(e=>e.EmployeeId == empId .val;
          public Employee this[HRId hrId] => 
                 this.FirstorDefault(e=>e.EmployeeId == hrId.val;
      }
