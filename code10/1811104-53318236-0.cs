    class Program
    {
        public static int EmployeeId {get;set;}
    }
    class OtherWindow
    {
        void Function()
        {
           int employeeId = Program.EmployeeId;
        }
    }
