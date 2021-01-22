    public enum Departments
    {
        Finance,
        Technology,
        Sales
    }
    public class Employee
    {
        Departments _employeeDepartment;
        public Employee() {}
        public Employee(Department EmployeeDepartment)
        {
            _employeeDepartment = EmployeeDepartment;
        }
    }
