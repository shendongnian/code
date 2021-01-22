    protected IEnumerable<Employee> GetEmployees ()
    {
       List<Employee> list = new List<Employee>();
       DataSet ds = Employee.searchEmployees("Byron");
       foreach (DataRow dr in ds.Tables[0].Rows)
       {
           yield return new Employee(dr);
       }
    }
