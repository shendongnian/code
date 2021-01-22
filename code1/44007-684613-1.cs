    public class Employee : Person
    {
        private int employeeID;
        public Employee() { }
        public Employee(Person newEmployee) : this()
        {
            base.Assign(newEmployee);
        }
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        protected new void Assign(Employee otherEmployee)
        {
            base.Assign(otherEmployee);
            EmployeeID = otherEmployee.EmployeeID;
        }
    }
