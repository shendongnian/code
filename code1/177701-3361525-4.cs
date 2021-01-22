    public class MainViewModel
    {
        private readonly IEnumerable<Employee> _employees;
        public MainViewModel(IEnumerable<Employee> employees)
        {
            _employees = employees;
        }
        public IEnumerable<Employee> Employees
        {
            get { return _employees; }
        }
    }
