    public IEnumerable<Customer> DoSomething(string propertyName)
    {
        using (var context = _contextFactory.CreateReadOnly())
        {                
            return context.Customers.OrderBy(propertyName).ToList();
        }
    }
