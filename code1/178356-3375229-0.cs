    class MyClass
    {
        // Declare this at the class level
        List<string> employeeList;
        public EmployeeManager()
        {
             // Assign, but do not redeclare in the constructor
             employeeList = new List<string>();
        }
        public void AddEmployee()
        {
             // This now exists in this scope, since it's part of the class
             employeeList.add("Donald");
        }
    }
