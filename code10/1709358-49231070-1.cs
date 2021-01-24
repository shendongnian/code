    public class EmployeeComparer : : IEqualityComparer<Employee> {
        // Employees are equal if their porperties are equal.
        public bool Equals(Employee x, Employee y) {
    
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
    
            // Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            // Check whether the employee's properties are equal.
            return x.Name == y.Name 
                && x.Address == y.Address
                && x.Gender == y.Gender
                && x.Salary == y.Salary;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(Employee employee){
            // Check whether the object is null
            if (Object.ReferenceEquals(employee, null)) return 0;
    
            // Get hash codes for properties if they are not null.
            int hashEmployeeName = employee.Name == null ? 0 : employee.Name.GetHashCode();
            int hashEmployeeAddress = employee.Address == null ? 0 : employee.Address.GetHashCode();
            int hashEmployeeGender = employee.Gender == null ? 0 : employee.Gender.GetHashCode();
            int hashEmployeeSalary = employee.Salary == null ? 0 : employee.Salary.GetHashCode();
    
            // Calculate the hash code for the whole object using XOR.
            return hashEmployeeName ^ hashEmployeeAddress ^ hashEmployeeGender ^ hashEmployeeSalary;
        }
    }
