    class Employee
    {
        private string name;
        private string address;
        // Pass the current object instance to another class:
        public decimal Salary 
        {
            get { return SalaryInfo.CalculateSalary(this); }
        }
    
        public Employee(string name, string address) 
        {
            // Inside this constructor, the name and address private fields
            // are hidden by the paramters...
            this.name = name;
            this.address = address;
        } 
    }
