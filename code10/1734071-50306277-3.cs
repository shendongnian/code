    public interface IDepartmentContext
    {
        int DepartmentId { get; set; }
    }
    public class DepartmentContext : IDepartmentContext
    {
        public int DepartmentId { get; set; }
    }
    public class Department
    {
        public int DepartmentId { get; set; }
    }
