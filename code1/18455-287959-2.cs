    public class EmployeeCollection: List<Employee>
    {
        public Employee this[int employeeId]
        {   
            get 
            { 
                foreach(var emp in this)
                {
                    if (emp.EmployeeId == employeeId)
                        return emp;
                }
                return null;
            }
        }
        
        public Employee this[string employeeName]
        {   
            get 
            { 
                foreach(var emp in this)
                {
                    if (emp.Name == employeeName)
                        return emp;
                }
                return null;
            }
        }
    }
