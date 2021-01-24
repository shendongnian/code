    // m => 
    var parameterExpression = Expression.Parameter(typeof(Equipment), "m");
    // m.Model
    var modelProperty = Expression.Property(parameterExpression, nameof(Equipment.Model));
    // m.Model != null
    var nonNullExpression = Expression.NotEqual(modelProperty, Expression.Constant(null, typeof(string)));
    // SearchTerm
    var searchTermConstant = Expression.Constant(SearchTerm);
    // m.Model.Contains(SearchTerm)
    var containsExpression = Expression.Call(modelProperty, contains, searchTermConstant);
    // m.Model != null && m.Model.Contains(SearchTerm)
    var andExpression = Expression.AndAlso(nonNullExpression, containsExpression);
    // m => ...
    var lambda = Expression.Lambda<Func<Equipment, bool>>(andExpression, parameterExpression);
