    // if no data provided, use default - _employees
    private void Func()
    {
        Func(_employees);
    }
    // In case of explicit data provided - use it
    //TODO: set employees type being as general as possible; 
    // at least IList<Employee> or even IEnumerable<Employee>
    private void Func(IList<Employee> employees)
    {
        ...
    }  
