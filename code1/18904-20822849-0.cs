    class Employee
    {
        // Private Fields for Employee
        private int id;
        private string name;
        
        //Property for id variable/field
        public int EmployeeId
        {
           get
           {
              return id;
           }
           set
           {
              id = value;
           }
        }
        //Property for name variable/field
        public string EmployeeName
        {
           get
           {
              return name;
           }
           set
           {
              name = value;
           }
       }
    }
    class MyMain
    {
        public static void Main(string [] args)
        {
           Employee aEmployee = new Employee();
           aEmployee.EmployeeId = 101;
           aEmployee.EmployeeName = "Sundaran S";
        }
    }
