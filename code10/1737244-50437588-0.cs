      // m => 
                    var parameterExpression = Expression.Parameter(typeof(Equipment), "m");
    
                    // m.Model
                    var modelProperty = Expression.Property(parameterExpression, Column);
                    // m.Model != null
                    var nonNullExpression = Expression.NotEqual(modelProperty, Expression.Constant(null, typeof(string)));
    
                    // SearchTerm
                    var searchTermConstant = Expression.Constant(SearchTerm);
    
                    // m.Model.Contains(SearchTerm)
                    var containsExpression = Expression.Call(modelProperty, "contains", null, searchTermConstant);
    
                    // m.Model != null && m.Model.Contains(SearchTerm)
                    var andExpression = Expression.AndAlso(nonNullExpression, containsExpression);
    
                    var lambda1 = Expression.Lambda<Func<Equipment, string>>(modelProperty, parameterExpression);
                    var lambda2 = Expression.Lambda<Func<Equipment, bool>>(andExpression, parameterExpression);
    
                    var compiledLambda1 = lambda1.Compile();
                    var compiledLambda2 = lambda2.Compile();
    
                    var distinctValues1 = db.Equipment.Where(compiledLambda2).Select(compiledLambda1).Distinct().ToList();
