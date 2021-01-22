    public List<Employee> GetEmployee(int id)
    {
         return ( from e in MyDataContext.Employees
                       select new Employee()
                       {
                         e.empId = id
                       }
                 ).ToList();
    }
