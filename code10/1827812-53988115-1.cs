    public class DepartmentModel
    {
        public long Id { get; set; }
        public List<EmployeeModel> Employees { get; set; }
    }
    public class EmployeeModel
    {
        public long Id { get; set; }
        public long DepartmentId { get; set; }
    }
