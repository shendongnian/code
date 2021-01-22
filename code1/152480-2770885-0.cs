    public class EmployeeLoader
    {
        private List<String> _Employees = null;
        public List<String> Employees
        {
            get
            {
                if (_Employees == null)
                {
                    LoadEmployees();
                }
                return _Employees;
            }
        }
        private void LoadEmployees()
        {
            //Load Data
        }
    }
