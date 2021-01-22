    // This method ANDs equality expressions for each property, like so:
    //
    // customers.Where(c => c.Property1 == value1 && c.Property2 == value2 && ...);
    private IQueryable<Customer> FilterQuery(IQueryable<Customer> customers, IDictionary<string, string> filter)
    {
        var parameter = Expression.Parameter(typeof(Customer), "c");
        Expression filterExpression = null;
        foreach(var filterItem in filter)
        {
            var property = typeof(Customer).GetProperty(filterItem.Key);
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var equality = Expression.Equal(propertyAccess, Expression.Constant(filterItem.Value));
            if(filterExpression == null)
            {
                filterExpression = equality;
            }
            else
            {
                filterExpression = Expression.And(filterExpression, equality);
            }
        }
        if(filterExpression != null)
        {
            var whereBody = Expression.Lambda<Func<Customer, bool>>(filterExpression, parameter);
            customers = customers.Where(whereBody);
        }
					
        return customers;
    }
