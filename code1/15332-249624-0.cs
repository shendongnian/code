    // Examples for GetEmployees
    public IList<Employee> GetEmployeesBySupervisor(int supervisorId);
    public IList<Employee> GetEmployeesBySupervisor(Supervisor supervisor);
    public IList<Employee> GetEmployeesBySupervisor(Person supervisor);
    public IList<Employee> GetEmployeesByDepartment(int departmentId);
    public IList<Employee> GetEmployeesByDepartment(Department department);
    
    // Examples for GetProduct
    public IList<Product> GetProductById(int productId) {...}
    public IList<Product> GetProductById(params int[] productId) {...}
    
    public IList<Product> GetProductByCategory(Category category) {...}
    public IList<Product> GetProductByCategory(IEnumerable<Category> category) {...}
    public IList<Product> GetProductByCategory(params Category[] category) {...}
