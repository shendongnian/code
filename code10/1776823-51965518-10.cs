    public IEnumerable<Customer> DoSomething(Expression<Func<IObjectWithProperties, object>> sortColumn)
    {
        using (var context = _contextFactory.CreateReadOnly())
        {
            return context.Customers.OrderBy(sortColumn).Cast<Customer>().ToList(); 
        }    	   
    }
