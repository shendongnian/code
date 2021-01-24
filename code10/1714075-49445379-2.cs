    public class DepartmentViewModel
    {
        public int id{get;set};
        public string name {get;set;}
        public IEnumerable<Employee> Employees { get; set; }
    }
