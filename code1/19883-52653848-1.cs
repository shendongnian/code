    public static IQueryable<T> SortBy<T>(this IQueryable<T> source, 
                                          String propertyName, 
                                          WebControls.SortDirection direction)
        {
        	if (source == null) throw new ArgumentNullException("source");
        	if (String.IsNullOrEmpty(propertyName)) return source;
        
        	// Create a parameter to pass into the Lambda expression
        	//(Entity => Entity.OrderByField).
        	var parameter = Expression.Parameter(typeof(T), "Entity");
        
        	//  create the selector part, but support child properties (it works without . too)
        	String[] childProperties = propertyName.Split('.');
        	MemberExpression property = Expression.Property(parameter, childProperties[0]);
        	for (int i = 1; i < childProperties.Length; i++)
        	{
        		property = Expression.Property(property, childProperties[i]);
        	}
        
        	LambdaExpression selector = Expression.Lambda(property, parameter);
        
        	string methodName = (direction > 0) ? "OrderByDescending" : "OrderBy";
        
        	MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName,
        									new Type[] { source.ElementType, property.Type },
        									source.Expression, Expression.Quote(selector));
        
        	return source.Provider.CreateQuery<T>(resultExp);
        }
