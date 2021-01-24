    ParameterExpression pe = Expression.Parameter(Customer, "cust");
    var _prpToUse = Expression.Property(pe, "CustomerId"); 
    var _cnstToUse = Expression.Constant(10); 
    var qry = Expression.Equal(_prpToUse, _cnstToUse);
    MethodCallExpression whereExpression = Expression.Call(  
          typeof(Queryable),  
          "Where",  
          new Type[] { lst.ElementType },  
          lst.Expression,  
          Expression.Lambda<Func<Customer, bool>>(qry, new 
          ParameterExpression[] { pe }));  
    lstData.Provider.CreateQuery<Customer>(whereExpression).FirstOrDefault();
  
