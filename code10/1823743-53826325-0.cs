    public class Employee
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string HiredDate { get; set; } = "";
        private List<Employee> _subordinates = new List<Employee>();
        public ReadOnlyCollection<Employee> Subordinates => _subordinates.AsReadOnly();
        public void AddSubordinate(Employee employee)
        {
            _subordinates.Add(Employee);
            //the manager is 'this'
            var managerLastName = this.LastName;
         }
    }
