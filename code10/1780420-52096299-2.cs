    public async Task<EmployeeDto> GetEmployee(int eId)
    {
        try
        {
            return GetService<IEmployeeService>().GetEmployeeById(eId);
        }
        catch (InvalidOperationException) //If it's suitable
        {
            return null;
        }
    }
