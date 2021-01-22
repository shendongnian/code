    public IQueryable<SuperEmployee> GetSuperEmployees()
    {        
      return this.Context.SuperEmployeeSet               
             .Include("Quotes")               
             .Where(emp=>emp.Issues>10)               
             .OrderBy(emp=>emp.EmployeeID);
    }
