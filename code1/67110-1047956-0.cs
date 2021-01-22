    public class DepartmentBrief
    {
        public string Name { get; set; }
    }
    public class Department : DepartmentBrief
    {
        public Department()
        {
            Departments = new List<DepartmentBrief>();
        }
        public IEnumerable<DepartmentBrief> Departments { get; private set; }
    }
    public class UserBase
    {
        public DepartmentBrief Department { get; set; }   
    }
