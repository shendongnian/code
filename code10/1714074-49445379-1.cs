    public class EmployeeViewModel
    {
        public int id{get;set};
        public string name{get;set;}
        public IEnumerable<Deparment> Departments { get; set; }
    }
