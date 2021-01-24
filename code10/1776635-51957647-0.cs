    class EmployeeHelper
    {
        public Employee FindEmployee(string id)
        {
            List<Employee> temporaryList = GetEmployees();  //Use then throw away
            return temporaryList.Single( e => e.Id == id );
        }
    }
           
