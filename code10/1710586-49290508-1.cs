    static List<Person> GetPerson(int? countryID = null, int? stateID = null, int? cityID = null, int? zip = null)
    {
        //create a new expression for the type of person this.
        var paramExpr = Expression.Parameter(typeof(Person));
    
        //var equalExpression = Expression.Empty();
        BinaryExpression equalExpression = null;
    
        if (countryID.HasValue)
        {
            var e = BuildExpression(paramExpr, "CountryId", countryID.Value);
            if (equalExpression == null)
                equalExpression = e;
            else
                equalExpression = Expression.And(equalExpression, e);
        }
        if (stateID.HasValue)
        {
            var e = BuildExpression(paramExpr, "StateID", stateID.Value);
            if (equalExpression == null)
                equalExpression = e;
            else
                equalExpression = Expression.And(equalExpression, e);
        }
        if (equalExpression == null)
        {
            return new List<Person>();
        }
    
        //next we convert the expression into a lamba expression
        var lExpr = Expression.Lambda<Func<Person, bool>>(equalExpression, paramExpr);
        //finally we query our dataset
        return persons.AsQueryable().Where(lExpr).ToList();
    }
    
    static BinaryExpression BuildExpression(Expression expression, string propertyName, object value)
    {
        //next we create a property expression based on the property named "CountryID" (this is case sensitive)
        var property = Expression.Property(expression, propertyName);
    
        //next we create a constant express based on the country id passed in.
        var constant = Expression.Constant(value);
    
        //next we create an "Equals" express where property equals containt. ie. ".CountryId" = 1
        return Expression.Equal(property, constant);
    }
