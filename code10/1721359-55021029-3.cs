     public class EmployeeViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public EmployeeDepartment employeeDepartment { get; set; }
    }
    public class EmployeeDepartment {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
