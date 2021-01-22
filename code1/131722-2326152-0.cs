    public IQueryable<IEmployee> Query
    {
        get
        {
            return this._context.Employees.Cast<IEmployee>();
    
        }
    }
