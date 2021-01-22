    public class EmployeeViewModel
    {
        private readonly Employee _employee;
        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }
        public string Name { get { return _employee.Name; } }
        public string CompanyName { get { return _employee.Company == null ? "Unemployed" : _employee.Company.CompanyName; } }
    }
