    public class CustomerViewModel
    {
        public string ProjectName { get; set; }
        public List<EmployeeHoursViewMode> EmployeeHours { get; set; }
    }
    public class EmployeeHoursViewModel
    {
        public string Employee { get; set; }
        public int Hours{ get; set; }
    }
