    public Employee GetEmployee()
    {
         return new Hydrator<Employee>().GetSingle();
    }
    
    public IList< Employee> GetEmployees()
    {
     return new Hydrator<Employee>().GetList(100);
    }
